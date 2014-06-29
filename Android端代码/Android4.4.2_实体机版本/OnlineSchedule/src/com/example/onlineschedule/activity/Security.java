package com.example.onlineschedule.activity;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.SharedPreferences;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import com.example.onlineschedule.R;
import android.widget.EditText;
import android.widget.Button;

import static android.content.SharedPreferences.*;

/**
 * Created with IntelliJ IDEA.
 * User: rft
 * Date: 13-2-22
 * Time: 下午12:28
 * To change this template use File | Settings | File Templates.
 */
public class Security extends Activity {
    private EditText etOri;
    private EditText etNew;
    private EditText etNew2;

    public static boolean Logined = false;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.setContentView(R.layout.security);
        etOri = (EditText) findViewById(R.id.etOriPwd);
        etNew = (EditText) findViewById(R.id.etNewPwd);
        etNew2 = (EditText) findViewById(R.id.etNewPwd2);
        Button btn;
        btn = (Button) findViewById(R.id.btnSetPwd);
        btn.setOnClickListener(onBtnSetPwdClickListener);

    }

    protected View.OnClickListener onBtnSetPwdClickListener = new View.OnClickListener() {

        @Override
        public void onClick(View view) {
            SharedPreferences ui = getSharedPreferences("user_info", 0);
            String strCur = ui.getString("password", "");
            String strOri = etOri.getText().toString();
            String strNew = etNew.getText().toString();
            String strNew2 = etNew2.getText().toString();
            if (strCur != null && strCur.length() > 0) {
                if (!strCur.equals(strOri)) {
                    new AlertDialog.Builder(Security.this)
                            .setTitle("提示")
                            .setMessage("原密码不正确，请重新输入!")
                            .setPositiveButton("确定", null)
                            .show();
                    return;
                }
            }
            if (!strNew.equals(strNew2)) {
                new AlertDialog.Builder(Security.this)
                        .setTitle("提示")
                        .setMessage("两次输入的密码不一致,请重新输入!")
                        .setPositiveButton("确定", null)
                        .show();
                return;

            }

            ui.edit().putString("password", strNew).commit();
            finish();
        }
    };
}