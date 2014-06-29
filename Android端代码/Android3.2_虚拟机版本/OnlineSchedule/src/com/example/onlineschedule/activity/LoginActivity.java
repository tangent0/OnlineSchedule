package com.example.onlineschedule.activity;

import java.util.ArrayList;

import android.app.Activity;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.onlineschedule.util.HttpThread;
import com.example.onlineschedule.util.WebServiceClient;
import com.example.onlineschedule.util.LocalStorage;
import com.example.onlineschedule.util.MessageBox;
import com.example.onlineschedule.util.SysParam;

import org.apache.http.message.BasicNameValuePair;
import org.json.JSONObject;
import com.example.onlineschedule.R;

/**
 * Created with IntelliJ IDEA.
 * User: rft
 * Date: 13-4-8
 * Time:
 * To change this template use File | Settings | File Templates.
 */
public class LoginActivity extends Activity {
    private EditText mNameEdit;
    private EditText mPasswordEdit;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.setContentView(R.layout.login);
        mNameEdit = (EditText)findViewById(R.id.login_name_edit);
        mPasswordEdit = (EditText)findViewById(R.id.login_pwd_edit);
        Button btn;
        btn = (Button)findViewById(R.id.login_ok_btn);
        btn.setOnClickListener(this.onOkBtnClickListener);
        btn = (Button)findViewById(R.id.login_cancel_btn);
        btn.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view) {
                LoginActivity.this.finish();
            }
        });



    }
    private View.OnClickListener onOkBtnClickListener = new  View.OnClickListener(){

        @Override
        public void onClick(View view) {
            String strUserName = mNameEdit.getText().toString();
            String strPwd = mPasswordEdit.getText().toString();
            try {
                ArrayList<BasicNameValuePair> params = new ArrayList<BasicNameValuePair>();
                params.add(new BasicNameValuePair("studentNo", strUserName));
                params.add(new BasicNameValuePair("pwd", strPwd));
                HttpThread th = new HttpThread("ScheduleService.asmx","Login",params,mHttpHandler);
                th.start();
                /*
                String strClassNo = WebServiceClient.callWebService("ScheduleService.asmx", "Login", params, null);
                if (!"".equals(strClassNo) && !"None".equals(strClassNo)) {
                   Toast.makeText(LoginActivity.this, "登录成功", Toast.LENGTH_LONG).show();
                   SysParam.ClassNo = strClassNo;
                   LocalStorage ls =new LocalStorage(LoginActivity.this);
                   ls.putString(SysParam.CLASS_NO, strClassNo);
                   
                }
                else
                {
                	Toast.makeText(LoginActivity.this, "登录失败", Toast.LENGTH_LONG).show();
                }
                */
            } catch (Exception ex) {
                Log.e("LoadAppData", ex.getMessage(), ex);
            }
        }
    };
    public Handler mHttpHandler = new Handler(){

        @Override
        public void  handleMessage (Message msg){
            if(msg.what == 1){
                //success to access http service
                Bundle data = msg.getData();
                if(data == null){
                    return;
                }
                String strMethod = data.getString("MoehodName");
                String strResult = data.getString("Result");
                
                //print StrResult to Logcat
                System.out.println("LoginActivity: StrMethod = "+strMethod);
                System.out.println("LoginActivity: StrResult = "+strResult);
                
                if (!"".equals(strResult) && !"None".equals(strResult)) {
                    Toast.makeText(LoginActivity.this, "登录成功", Toast.LENGTH_LONG).show();
                    SysParam.ClassNo = strResult;
                    LocalStorage ls = new LocalStorage(LoginActivity.this);
                    ls.putString(SysParam.CLASS_NO, strResult);
                    LoginActivity.this.finish();
                    return;
                 }
                 else
                 {
                 	Toast.makeText(LoginActivity.this, "登录失败", Toast.LENGTH_LONG).show();
                 }
            }
            else if( msg.what == 0 ){
                Bundle data = msg.getData();
                String strUri = data.getString("URI");
                String strExption = data.getString("Exception");
                Toast.makeText(LoginActivity.this, "登录失败:" + strUri + "." + strExption, 500).show();
            }

        }

    };
}