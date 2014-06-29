package com.example.onlineschedule.activity;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import org.apache.http.message.BasicNameValuePair;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.InputType;
import android.util.Log;
import android.view.*;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Toast;

import com.example.onlineschedule.R;
import com.example.onlineschedule.entity.Remind;
import com.example.onlineschedule.entity.Schedule;
import com.example.onlineschedule.util.DBHelper;
import com.example.onlineschedule.util.HttpThread;
import com.example.onlineschedule.util.LocalStorage;
import com.example.onlineschedule.util.SysParam;
import com.example.onlineschedule.util.WebServiceClient;
import com.example.onlineschedule.util.XmlScheduleParser;

/**
 * Created with IntelliJ IDEA.
 * User: rft
 * Date: 13-2-19
 * Time: 下午7:08
 * To change this template use File | Settings | File Templates.
 */
public class MainActivity extends Activity {
	public final static String TAG = "Schedule";
	private DBHelper db;
	public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        db= new DBHelper(this);
        setContentView(R.layout.main_activity);
        Button btn = (Button) findViewById(R.id.btnSetSallybus);
        btn.setOnClickListener(onBtnSetSallybusClickListener);

        btn = (Button) findViewById(R.id.btnAddNote);
        btn.setOnClickListener(onBtnAddNoteClickListener);

        btn = (Button) findViewById(R.id.btnViewSallybus);
        btn.setOnClickListener(onBtnViewSallybusClickListener);

        btn = (Button) findViewById(R.id.btnViewNote);
        btn.setOnClickListener(onBtnViewNoteClickListener);
        
        btn = (Button)this.findViewById(R.id.btnMap);
        btn.setOnClickListener(onMapClick);
        
        btn = (Button)this.findViewById(R.id.btn_update_remind);
        btn.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				downloadRemind();				
			}
		});
        
        String strWebHostAddr = getWebHostAddress();
        if (strWebHostAddr.length() < 4) {
            //saveWebHostAddress("http://192.168.10.102/WebStation/service");
        	saveWebHostAddress("http://10.0.2.2/schedule/service");
        }
        
    	LocalStorage ls = new LocalStorage(this);    	
    	SysParam.FirstWeek = ls.getInt(SysParam.FIRST_WEEK, 1);
    	
    }

    public boolean onCreateOptionsMenu(Menu menu) {
        super.onCreateOptionsMenu(menu);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.main_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
        /*
            case R.id.miSetPassword:
                Intent intent = new Intent(MainActivity.this, Security.class);
                MainActivity.this.startActivity(intent);
                break;
                */
            case R.id.miChCalendar:
                this.setupFirstTeachingWeek();
                break;
                
            case R.id.miSetServerAddr:
            	setRemoteHost();
                break;
            case R.id.miClearSchedule:
            	db.clearSchedule();
            	break;

        }

        return true;
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        /*
        switch (item.getItemId())
        {
            case R.id.miSetPassword:
                Intent intent = new Intent(MainActivity.this,Security.class);
                MainActivity.this.startActivity(intent);
                break;
        }
        */
        return super.onContextItemSelected(item);
    }


    /**
     * 设置课程表
     */
    public View.OnClickListener onBtnSetSallybusClickListener = new View.OnClickListener() {

        @Override
        public void onClick(View view) {
            Intent intent = new Intent(MainActivity.this, ScheduleInsert.class);
            MainActivity.this.startActivity(intent);

        }
    };
    /**
     * 登录
     */
    public View.OnClickListener onBtnAddNoteClickListener = new View.OnClickListener() {

        @Override
        public void onClick(View view) {
            //To change body of implemented methods use File | Settings | File Templates.
           //Intent intent = new Intent(MainActivity.this, DiaryNew.class);
        	Intent intent = new Intent(MainActivity.this, LoginActivity.class);
            MainActivity.this.startActivity(intent);
        }
    };
    /**
     * 下载课程表
     */
    public View.OnClickListener onBtnViewNoteClickListener = new View.OnClickListener() {

        @Override
        public void onClick(View view) {
        	
        	System.out.println("btnViewNote");
        	downloadSchedule();
        }
    };
    private void downloadSchedule()
    {
    	LocalStorage ls =new LocalStorage(this);
    	String strClassNo = ls.getString(SysParam.CLASS_NO, "");
    	if(strClassNo.isEmpty())
    	{
    		Toast.makeText(this, "请登录后，再下载课程表", Toast.LENGTH_LONG).show();
    		return;
    	}
    	
         try {
             ArrayList<BasicNameValuePair> params = new ArrayList<BasicNameValuePair>();
             params.add(new BasicNameValuePair("classNo", strClassNo));
             HttpThread th = new HttpThread("ScheduleService.asmx","MySchedule",params,mHttpHandler);
             th.start();
             
         } catch (Exception ex) {
             Log.e("LoadAppData", ex.getMessage(), ex);
         }
    	
    }
    private void downloadRemind(){
        try {
            ArrayList<BasicNameValuePair> params = new ArrayList<BasicNameValuePair>();
            params.add(new BasicNameValuePair("maxRow", "100"));
            HttpThread th = new HttpThread("ScheduleService.asmx","Remind",params,mHttpHandler);
            th.start();
            
        } catch (Exception ex) {
            Log.e("LoadAppData", ex.getMessage(), ex);
        }
    }
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
                System.out.println("MainActivity: StrMethod = "+strMethod);
                System.out.println("MainActivity: StrResult = "+strResult);
                
                if(strMethod.equalsIgnoreCase("MySchedule"))
                {
	                if (strResult == null || strResult.isEmpty()) {
	                    Toast.makeText(MainActivity.this, "下载课程表失败", Toast.LENGTH_LONG).show();
	                    return;
	                 }
	                ArrayList<Schedule> listData = XmlScheduleParser.Parse(strResult);
	                if(listData != null && listData.size() > 0)
	                {
	                	for(int i=0;i<listData.size();i++)
	                	{
	                		Schedule obj = listData.get(i);
	                		db.updateCourse(obj.week, obj.section, obj.course, obj.address);
	                	}
	                }
	                Toast.makeText(MainActivity.this, "课程表下载已完成", Toast.LENGTH_LONG).show();
	                return;
                }
                else if(strMethod.equalsIgnoreCase("Remind"))
                {//处理重要提醒
                	if (strResult == null || strResult.isEmpty()) {
	                    Toast.makeText(MainActivity.this, "下载重要提醒失败", Toast.LENGTH_LONG).show();
	                    return;
	                 }
	                ArrayList<Remind> remindList = XmlScheduleParser.ParseRemind(strResult);
	                db.deleteAll("remind");
	                if(remindList != null && remindList.size() > 0)
	                {
	                	for(int i=0;i<remindList.size();i++)
	                	{
	                		Remind obj = remindList.get(i);
	                		db.insertRemind(obj.Id, obj.Note, obj.Month, obj.Day);
	                	}
	                }
	                Toast.makeText(MainActivity.this, "下载重要提醒已完成", Toast.LENGTH_LONG).show();
	                return;
                }
            }
           

        }

    };
    public View.OnClickListener onMapClick = new View.OnClickListener() {
		
		@Override
		public void onClick(View v) {
			// TODO Auto-generated method stub
			Intent i = new Intent(MainActivity.this,MapActivity.class);
			MainActivity.this.startActivity(i);
		}
	};
    /**
     * 查看日程
     */
    /*
    public View.OnClickListener onBtnViewNoteClickListener = new View.OnClickListener() {

        @Override
        public void onClick(View view) {

            if (!Security.Logined) {
                LayoutInflater inflater = getLayoutInflater();
                final View inputView = inflater.inflate(R.layout.input_string, (ViewGroup) findViewById(R.id.etInputString));
                new AlertDialog.Builder(MainActivity.this).setTitle("请输入查看日程密码")
                        .setView(inputView)
                        .setNeutralButton(R.string.ok, new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialogInterface, int i) {
                                EditText etPwd = (EditText) inputView.findViewById(R.id.etInputString);
                                String strInputPwd = etPwd.getText().toString();
                                SharedPreferences prefs = getSharedPreferences("user_info", MODE_PRIVATE);
                                String strPwd = prefs.getString("password", "");
                                if (!strPwd.equals("")) {
                                    if (strPwd.equals(strInputPwd)) {
                                        Security.Logined = true;
                                    }
                                } else {
                                    Security.Logined = true;
                                }
                                if (!Security.Logined) {

                                    new AlertDialog.Builder(MainActivity.this)
                                            .setTitle("提示")
                                            .setMessage("密码不正确")
                                            .setPositiveButton("确定", null)
                                            .show();
                                    return;
                                }
                            }
                        })
                        .show();
                return;
            }
            if (!Security.Logined) {
                new AlertDialog.Builder(MainActivity.this)
                        .setTitle("提示")
                        .setMessage("密码不正确")
                        .setPositiveButton("确定", null)
                        .show();
                return;
            }
            Intent intent = new Intent(MainActivity.this, CalendarActivity.class);
            MainActivity.this.startActivity(intent);
        }
    };
    */
    /**
     * 查看课程表
     */
    public View.OnClickListener onBtnViewSallybusClickListener = new View.OnClickListener() {

        @Override
        public void onClick(View view) {
            Intent intent = new Intent(MainActivity.this, ScheduleShow.class);
            MainActivity.this.startActivity(intent);
        }
    };

    /**
     * 保存web服务地址到系统配置文件中
     *
     * @param strWebHostAddr
     */
    public void saveWebHostAddress(String strWebHostAddr) {
       
        LocalStorage ls =new LocalStorage(this);
        ls.putString(SysParam.HOST_NAME, strWebHostAddr);
        SysParam.ServerAddress = strWebHostAddr;
        WebServiceClient.ServiceHostAddress = strWebHostAddr;
    }

    /**
     * 获取web服务地址
     */
    public String getWebHostAddress() {
    	LocalStorage ls = new LocalStorage(this);
        String strAddr = ls.getString(SysParam.HOST_NAME, "http://192.168.10.102/WebStation/service");
        WebServiceClient.ServiceHostAddress = strAddr;
        SysParam.ServerAddress= strAddr;
        return strAddr;
    }
    /**
     * 设置web服务地址
     */
    private void setRemoteHost() {
        LayoutInflater inflater = getLayoutInflater();
        final View inputView = inflater.inflate(R.layout.input_string, (ViewGroup) findViewById(R.id.etInputString));
        String strOldWebHostAddr = getWebHostAddress();
        try {
            EditText edit = (EditText) inputView.findViewById(R.id.etInputString);
            edit.setText(strOldWebHostAddr);
            edit.setInputType(InputType.TYPE_CLASS_TEXT);
           
        } catch (Exception ex) {
           Toast.makeText(this, ex.getMessage(),Toast.LENGTH_SHORT).show();
        }
        new AlertDialog.Builder(MainActivity.this).setTitle("请输入Web服务地址")
                .setView(inputView)
                .setNeutralButton(R.string.ok, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                        EditText intputEdit = (EditText) inputView.findViewById(R.id.etInputString);
                        String strRemoteHost = intputEdit.getText().toString();
                        saveWebHostAddress(strRemoteHost);
                    }
                })
                .show();
        return;

    }
    
    private void setupFirstTeachingWeek() {
        LayoutInflater inflater = getLayoutInflater();
        final View inputView = inflater.inflate(R.layout.first_teaching_week, (ViewGroup) findViewById(R.id.ll_first_teaching_week));
        String strOldWebHostAddr = getWebHostAddress();
        try {
        	DatePicker datePicker;
        	datePicker = (DatePicker) inputView.findViewById(R.id.datePicker1);
          
           
        } catch (Exception ex) {
           Toast.makeText(this, ex.getMessage(),Toast.LENGTH_SHORT).show();
        }
        new AlertDialog.Builder(MainActivity.this).setTitle("请输入Web服务地址")
                .setView(inputView)
                .setNeutralButton(R.string.ok, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                       	DatePicker datePicker;
                    	datePicker = (DatePicker) inputView.findViewById(R.id.datePicker1);
                    	int year = datePicker.getYear();
                    	int month = datePicker.getMonth();
                    	int day = datePicker.getDayOfMonth();
                    	Calendar c = Calendar.getInstance();
                    	c.set(year, month, day);
                    	int firstWeek = c.get(Calendar.WEEK_OF_YEAR);
                    	LocalStorage ls = new LocalStorage(MainActivity.this);
                    	ls.putInt(SysParam.FIRST_WEEK, firstWeek);
                    	SysParam.FirstWeek = firstWeek;
                    }
                })
                .show();
        return;

    }

}