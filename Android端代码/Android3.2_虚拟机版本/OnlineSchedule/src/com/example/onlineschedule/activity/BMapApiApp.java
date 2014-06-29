package com.example.onlineschedule.activity;

import android.app.Application;
import android.util.Log;
import android.widget.Toast;
import com.baidu.mapapi.BMapManager;
import com.baidu.mapapi.MKEvent;
import com.baidu.mapapi.MKGeneralListener;

public class BMapApiApp extends Application {
	
	static BMapApiApp mMapApp;
	
	//Baidu MapAPI's manager class
	BMapManager mBMapMan = null;
	
	// Authorize Key
	// TODO: please input your baidu map api Key,
	// url: http://dev.baidu.com/wiki/static/imap/key/
	String mStrKey = "B8252192B6F970494A0FCEB503F2410D51505445";
	boolean m_bKeyRight = true;
	

	static class MyGeneralListener implements MKGeneralListener {
		@Override
		public void onGetNetworkState(int iError) {
			Log.d("MyGeneralListener", "onGetNetworkState error is "+ iError);
			Toast.makeText(BMapApiApp.mMapApp.getApplicationContext(), "Network error",
					Toast.LENGTH_LONG).show();
		}

		@Override
		public void onGetPermissionState(int iError) {
			Log.d("MyGeneralListener", "onGetPermissionState error is "+ iError);
			if (iError ==  MKEvent.ERROR_PERMISSION_DENIED) {
				// Key error
				Toast.makeText(BMapApiApp.mMapApp.getApplicationContext(),
						"Please input your authorize Key!",
						Toast.LENGTH_LONG).show();
                BMapApiApp.mMapApp.m_bKeyRight = false;
			}
		}
	}

	@Override
    public void onCreate() {
		Log.v("BMapApiDemoApp", "onCreate");
		mMapApp = this;
		mBMapMan = new BMapManager(this);
        try{
            mBMapMan.init(this.mStrKey, new MyGeneralListener());
            mBMapMan.getLocationManager().setNotifyInternal(10, 5);
        }
        catch(Exception ex)
        {
            Log.e("BaiDuException",ex.getMessage(),ex);
        }

//		if (mBMapMan != null) {
//			mBMapMan.destroy();
//			mBMapMan = null;
//		}
		
		super.onCreate();
	}

	@Override
	public void onTerminate() {
		// TODO Auto-generated method stub
		if (mBMapMan != null) {
			mBMapMan.destroy();
			mBMapMan = null;
		}
		super.onTerminate();
	}

}
