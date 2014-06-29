package com.example.onlineschedule.activity;

import android.R.string;
import android.app.Activity;
import android.content.Context;
import android.location.Location;
import android.location.LocationProvider;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.Button;

import com.example.onlineschedule.R;
import com.example.onlineschedule.entity.Dijkstra;
import com.example.onlineschedule.entity.MapNode;

import org.w3c.dom.Text;
import android.location.LocationManager;

import com.baidu.mapapi.BMapManager;
import com.baidu.mapapi.LocationListener;
import com.example.onlineschedule.activity.BMapApiApp;

/**
 * Created by Administrator on 14-5-1.
 */
public class MapActivity extends Activity {
    private EditText etCurrentLoc;
    private EditText etTargetLoc;
    private TextView tvPath;
    
    private Dijkstra  mapData;
    LocationListener mLocationListener = null;
    //
    LocationManager mGoogleLocationManager = null;
    android.location.LocationListener mGoogleLocationListener;
    
    String mProviderName;
    
    //
    Toast toast = null;
    
	public void printToastCurrenLocation(Location location) {
		// TODO Auto-generated method stub
		if(location != null){
			double longitude = location.getLongitude();
			double latitude = location.getLatitude();
			String strLog = String.format("current location:\r\n" +
					"longitude:%f\r\n" +
					"latitude:%f",
					longitude, latitude);
			
			System.out.println("strLog = String.format");
			
			MapNode node = mapData.findNearestBuilding(longitude, latitude);
			if(node != null){
				etCurrentLoc.setText(node.name);
				strLog += "\r\nAt Building No." + node.name;
			}
			
			//解决Toast重复显示的问题
			if (toast == null) {
				toast = Toast.makeText(MapActivity.this, strLog, Toast.LENGTH_SHORT);
			} else {
				toast.cancel();
				toast = Toast.makeText(MapActivity.this, strLog, Toast.LENGTH_SHORT);
			}
			
			toast.show();
			
			//System.out.println("toast.show(), toast = "+toast);
			
	        //Oncreate载入时，etTargetLoc获得焦点
	        //etTargetLoc.setText(etTargetLoc.getText().toString());
		}
	}
    
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.map_activity);
        etCurrentLoc = (EditText) this.findViewById(R.id.et_map_current_loc);
        etTargetLoc = (EditText)this.findViewById(R.id.et_map_target_loc);
        tvPath = (TextView)this.findViewById(R.id.map_tv_path);
              
        Button btn = (Button)this.findViewById(R.id.btn_map_go);
        btn.setOnClickListener(this.OnGoTargetClick);
        btn = (Button)this.findViewById(R.id.map_btn_back);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MapActivity.this.finish();
            }
        });
        mapData = new Dijkstra();
        
//        BMapApiApp app = (BMapApiApp)this.getApplication();
//		if (app.mBMapMan == null) {
//			app.mBMapMan = new BMapManager(getApplication());
//			app.mBMapMan.init(app.mStrKey, new BMapApiApp.MyGeneralListener());
//		}
//		app.mBMapMan.start();
//		System.out.println("app.mBMapMan.start()");
        //
		
		//防止Google和Baidu的GPS定位获得不同的经纬度的错误，将Baidu的方法内部语句注释掉
		
		//Google定位在ddms,或者利用 telnet下 geo fix手动更新当前地点
		mGoogleLocationManager = (LocationManager)getSystemService(Context.LOCATION_SERVICE);
		mGoogleLocationListener = new android.location.LocationListener() {
			
			@Override
			public void onLocationChanged(Location location) {
				
				printToastCurrenLocation(location);
			}

			@Override
			public void onStatusChanged(String provider, int status,
					Bundle extras) {
				// TODO Auto-generated method stub
				Log.v("GoogleGPS","onStatusChanged");
			}

			@Override
			public void onProviderEnabled(String provider) {
				// TODO Auto-generated method stub
				Log.v("GoogleGPS","onProviderEnabled");
			}

			@Override
			public void onProviderDisabled(String provider) {
				// TODO Auto-generated method stub
				Log.v("GoogleGPS","onProviderDisabled");
			}
			
		};
		
	    //Baidu定位 联网 实时更新 当前地点
//        mLocationListener = new LocationListener(){
//
//			@Override
//			public void onLocationChanged(Location location) {
//				printToastCurrenLocation(location);
//			}
//
//        };

    }
    
    @Override
    protected void onStart() {
    	super.onStart();
    	Location lastKnownLocation = null;
    	lastKnownLocation = mGoogleLocationManager.getLastKnownLocation(mGoogleLocationManager.GPS_PROVIDER);
    	
    	mProviderName = mGoogleLocationManager.GPS_PROVIDER;
    	if(!TextUtils.isEmpty(mProviderName)) {
    		mGoogleLocationManager.requestLocationUpdates(mProviderName, Toast.LENGTH_SHORT+1000, 0.3f, mGoogleLocationListener);
    		//原先设置minTime=3500ms，因为Toast.LENGTH_LONG为3秒左右，Toast.LENGTH_SHORT为2秒左右，实时的更新过快，minTime=0, minDistance=0
    		
    		//mGoogleLocationManager.requestLocationUpdates(provider, minTime, minDistance, listener);
    	}
    	
    	if(lastKnownLocation != null) {
    		printToastCurrenLocation(lastKnownLocation);
    	}
    }
    
    @Override
	protected void onPause() {
//		super.onPause();
//    	BMapApiApp app = (BMapApiApp)this.getApplication();
//		app.mBMapMan.getLocationManager().removeUpdates(mLocationListener);
//		app.mBMapMan.stop();
		
    	super.onPause();		
		//
        if(mGoogleLocationManager != null) {
        	mGoogleLocationManager.removeUpdates(mGoogleLocationListener);
        }
		
	}
	@Override
	protected void onResume() {
//		super.onResume();
//		BMapApiApp app = (BMapApiApp)this.getApplication();
//		// ע��Listener
//        app.mBMapMan.getLocationManager().requestLocationUpdates(mLocationListener);
//		app.mBMapMan.start();

		super.onResume();
		//
		Log.v("GoogleGPS","onResume.Provider Name:"+mProviderName);
		if(!TextUtils.isEmpty(mProviderName)) {
			mGoogleLocationManager.requestLocationUpdates(mProviderName, Toast.LENGTH_SHORT+1000, 0.3f, mGoogleLocationListener);
			//原先设置minTime=3500ms，因为Toast.LENGTH_LONG为3秒左右，Toast.LENGTH_SHORT为2秒左右，实时的更新过快，minTime=0, minDistance=0
		
		}
	}
    public View.OnClickListener OnGoTargetClick = new View.OnClickListener(){
        public  void onClick(android.view.View view)
        {
            Dijkstra map = new Dijkstra();

            int start =0;
            int target = 0;

            String src = etCurrentLoc.getText().toString();
            start = map.findNodeByName(src);
            String dst = etTargetLoc.getText().toString();
            target = map.findNodeByName(dst);
            if(start < 0 || target < 0){
                Toast.makeText(MapActivity.this,"查找位置失败",Toast.LENGTH_LONG).show();
                return;
            }
            String path = map.computeShortestPath(start,target);
            if(path.isEmpty()){
                path = "寻找最短路径失败";
            }
            tvPath.setText(path);
            Toast.makeText(MapActivity.this,"已完成路径查找.",Toast.LENGTH_LONG).show();
        }

    };
}