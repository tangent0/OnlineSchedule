package com.example.onlineschedule.util;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import org.apache.http.message.BasicNameValuePair;
import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.util.List;

/**
 * Created with IntelliJ IDEA.
 * User: rft
 * Date: 13-2-22
 * Time: 下午10:08
 * To change this template use File | Settings | File Templates.
 * 在开发虚拟机上，开发主机对应服务的地址为：10.0.2.2，不可直接使用主机地址或者localhost访问开发主机
 */
public class WebServiceClient {

    public final static String TAG = "AppStore";
    public final static String SHOW_EXCEPTION = "Exception";
    public final static int SHOW_EXCEPTION_MSG = 1;


    /**
     * web服务名称空间
     */
    public static String WSNameSpace = "http://tempuri.org/";
    /**
     * web服务器地址，若服务不是在根目录下，则连同相对目录一起
     */
    public static String ServiceHostAddress = "http://10.0.2.2:2646";

    public static String callWebService(String strServiceName, String strMethodName, List<BasicNameValuePair> params, Handler handler) {

        //Web服务名
        //String strServiceName = "Service1.asmx";
        //调用web服务方法名
        // String strMethodName = "HelloWorld";

        String soapAction = WSNameSpace + strMethodName;
        String serviceUrl = ServiceHostAddress + "/" + strServiceName;

        SoapObject soap = new SoapObject(WSNameSpace, strMethodName);
        for (int i = 0; i < params.size(); i++) {
            soap.addProperty(params.get(i).getName(), params.get(i).getValue());
        }

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER10);
        envelope.bodyOut = soap;
        envelope.dotNet = true;
        envelope.setOutputSoapObject(soap);
        envelope.encodingStyle = "UTF-8";

        HttpTransportSE transport = new HttpTransportSE(serviceUrl);

        try {
            transport.call(soapAction, envelope);
            SoapPrimitive result = (SoapPrimitive) envelope.getResponse();
            if (result != null) {
                ShowException("调用成功:" + result.toString(), handler);
                return result.toString();
            }
            return "";
        } catch (Exception ex) {
            if (handler != null) {
                ShowException(ex.getMessage(), handler);
            }
            ex.printStackTrace();
            Log.e(TAG, ex.getMessage(), ex);
        }
        return "";
    }

    /**
     * 调用webservice方法，调用结果以SoapObject的方式返回
     * 调用该方法之前需要首先设置  WSNameSpace   ServiceHostAddress 静态变量成员值
     *
     * @param strServiceName webservice 服务名称
     * @param strMethodName  webservice 方法名称
     * @param params         方法参数名-值对列表
     * @return 成功返回SoapObject 否则返回null
     */
    public static SoapObject callWebMethodForSoap(String strServiceName, String strMethodName, List<BasicNameValuePair> params) {
        String soapAction = WSNameSpace + strMethodName;
        String serviceUrl = ServiceHostAddress + "/" + strServiceName;

        SoapObject soap = new SoapObject(WSNameSpace, strMethodName);
        for (int i = 0; i < params.size(); i++) {

            soap.addProperty(params.get(i).getName(), params.get(i).getValue());
        }

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.bodyOut = soap;
        envelope.dotNet = true;
        envelope.setOutputSoapObject(soap);
        envelope.encodingStyle = "UTF-8";

        HttpTransportSE transport = new HttpTransportSE(serviceUrl);

        try {
            transport.call(soapAction, envelope);
            SoapObject result = (SoapObject) envelope.bodyIn;
            return result;
        } catch (Exception ex) {
            ex.printStackTrace();
            Log.e(TAG, ex.getMessage(), ex);
        }
        return null;
    }

    public static void ShowException(String strMsg, Handler handler) {
        if (handler == null)
            return;
        Message msg = handler.obtainMessage(SHOW_EXCEPTION_MSG);
        Bundle data = new Bundle();
        data.putString(SHOW_EXCEPTION, strMsg);
        msg.setData(data);
        handler.sendMessage(msg);

    }

    public static String uploadApp(String appName, String fileName, String desc, String category, byte[] fileContent, Handler handler) {

        //Web服务名
        String strServiceName = "AppService.asmx";
        //调用web服务方法名
        String strMethodName = "UploadApp";

        String soapAction = WSNameSpace + strMethodName;
        String serviceUrl = ServiceHostAddress + "/" + strServiceName;

        SoapObject soap = new SoapObject(WSNameSpace, strMethodName);

        soap.addProperty("appName", appName);
        soap.addProperty("appFileName", fileName);
        soap.addProperty("appDesc", desc);
        soap.addProperty("category", category);
        soap.addProperty("appFileContent", fileContent);


        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.bodyOut = soap;
        envelope.dotNet = true;
        envelope.setOutputSoapObject(soap);
        envelope.encodingStyle = "UTF-8";

        HttpTransportSE transport = new HttpTransportSE(serviceUrl);

        try {
            transport.call(soapAction, envelope);
            SoapPrimitive result = (SoapPrimitive) envelope.getResponse();
            if (result != null) {
                ShowException("调用成功:" + result.toString(), handler);
                return result.toString();
            }
            return "";
        } catch (Exception ex) {
            if (handler != null) {
                ShowException(ex.getMessage(), handler);
            }
            ex.printStackTrace();
            Log.e(TAG, ex.getMessage(), ex);
        }
        return "";
    }
}
