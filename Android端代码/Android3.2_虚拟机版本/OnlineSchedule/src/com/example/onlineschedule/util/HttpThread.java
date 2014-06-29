package com.example.onlineschedule.util;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;

import java.io.BufferedInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.List;

import org.apache.http.message.BasicNameValuePair;

/**
 * Created with IntelliJ IDEA.
 * User: rft
 * Date: 13-4-6
 * Time: ����10:26
 * To change this template use File | Settings | File Templates.
 */
public class HttpThread extends Thread{

    private String m_strURI;
    private Handler mHandler;
    private byte[] mContent;
    private String mTag;

    public HttpThread(String strURI,Handler handler){
        m_strURI = strURI;
        mHandler = handler;
        mTag = null;
    }
    public HttpThread(String serviceName,String methodName,List<BasicNameValuePair> params,Handler handler){
        this.mServiceName = serviceName;
        this.mMethodName = methodName;
        this.mParams = params;
        mHandler = handler;
        mTag = null;
    }
    public void setPostContent(byte[] content){
        mContent = content;
    }
    public String getTag(){
        return mTag;
    }
    public void setTag(String tag){
        mTag = tag;
    }

    @Override
    public void run(){

    	if(mServiceName != null && !mServiceName.isEmpty())
    	{
    		callWebService();
    	}
    	else
    	{
	        if(mContent!= null && mContent.length > 0){
	            post(mContent);
	        }
	        else{
	            request();
	        }
    	}

    }
    private String  mServiceName;
    private String mMethodName;
    private List<BasicNameValuePair> mParams;
    
    private void callWebService()
    {//String strServiceName, String strMethodName, List<BasicNameValuePair> params
    	String result = WebServiceClient.callWebService(mServiceName, mMethodName, mParams, null);
    	if(mHandler != null){
            Message msg = mHandler.obtainMessage(1);
            Bundle bdl = new Bundle();
            bdl.putString("MoehodName", mMethodName);
            bdl.putString("Result",result);
            bdl.putString("Tag",getTag());
            msg.setData(bdl);
            mHandler.sendMessage(msg);
        }
    	
    }
    private void post(byte[] content){
        String strUrl = SysParam.ServerAddress +  m_strURI;
        HttpURLConnection conn = null;
        try {

            URL url = new URL(strUrl);
            conn = (HttpURLConnection) url.openConnection();

            conn.setDoOutput(true);
            conn.setDoInput(true);
            conn.setRequestMethod("POST");
            conn.setUseCaches(false);

            conn.connect();
            DataOutputStream out = new DataOutputStream(conn.getOutputStream());
            out.write(content);
            out.flush();
            out.close();

            InputStream in = new BufferedInputStream(conn.getInputStream());
            int nContentLength = conn.getContentLength();
            byte[] buff = new byte[nContentLength];
            int nReaded = 0;
            int nRead = 0;
            while(nReaded < nContentLength){
                nRead = in.read(buff,nReaded,nContentLength-nReaded);
                if(nRead > 0 ){
                    nReaded += nRead;
                }
            }

            String strContentType = conn.getContentType();

            if(mHandler != null){
                Message msg = mHandler.obtainMessage(1);
                Bundle bdl = new Bundle();
                bdl.putString("URI", m_strURI);
                bdl.putString("ContentType",strContentType);
                bdl.putByteArray("Content",buff);
                bdl.putInt("ContentLength",nContentLength);
                bdl.putString("Tag",getTag());
                msg.setData(bdl);
                mHandler.sendMessage(msg);
            }

        }
        catch(IOException ioex){
            Message msg = mHandler.obtainMessage(0);
            Bundle bdl = new Bundle();
            bdl.putString("URI", m_strURI);
            bdl.putString("Exception",ioex.getMessage());
            msg.setData(bdl);
            mHandler.sendMessage(msg);
            return ;
        }
        catch(Exception ex){
            Message msg = mHandler.obtainMessage(0);
            Bundle bdl = new Bundle();
            bdl.putString("URI", m_strURI);
            bdl.putString("Exception",ex.getMessage());
            msg.setData(bdl);
            mHandler.sendMessage(msg);
            Log.d("Exception", ex.getMessage(), ex);
            return ;
        }
        finally {
            if(conn != null){
                conn.disconnect();
            }

        }
    }
    private void request() {
        String strUrl = SysParam.ServerAddress +  m_strURI;
        HttpURLConnection conn = null;
        try {

            URL url = new URL(strUrl);
            conn = (HttpURLConnection) url.openConnection();
            InputStream in = new BufferedInputStream(conn.getInputStream());
            int nContentLength = conn.getContentLength();
            byte[] buff = new byte[nContentLength];
            int nReaded = 0;
            int nRead = 0;
            while(nReaded < nContentLength){
                nRead = in.read(buff,nReaded,nContentLength-nReaded);
                if(nRead > 0 ){
                    nReaded += nRead;
                }
            }

            String strContentType = conn.getContentType();

            if(mHandler != null){
                Message msg = mHandler.obtainMessage(1);
                Bundle bdl = new Bundle();
                bdl.putString("URI", m_strURI);
                bdl.putString("ContentType",strContentType);
                bdl.putByteArray("Content",buff);
                bdl.putInt("ContentLength",nContentLength);
                msg.setData(bdl);
                mHandler.sendMessage(msg);
            }

        }
        catch(IOException ioex){
            Message msg = mHandler.obtainMessage(0);
            Bundle bdl = new Bundle();
            bdl.putString("URI", m_strURI);
            bdl.putString("Exception",ioex.getMessage());
            msg.setData(bdl);
            mHandler.sendMessage(msg);
            return ;
        }
        catch(Exception ex){
            Message msg = mHandler.obtainMessage(0);
            Bundle bdl = new Bundle();
            bdl.putString("URI", m_strURI);
            bdl.putString("Exception",ex.getMessage());
            msg.setData(bdl);
            mHandler.sendMessage(msg);
            Log.d("Exception", ex.getMessage(), ex);
            return ;
        }
        finally {
            if(conn != null){
                conn.disconnect();
            }

        }
    }

};
