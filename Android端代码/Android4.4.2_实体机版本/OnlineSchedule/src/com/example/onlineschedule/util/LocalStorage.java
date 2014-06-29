package com.example.onlineschedule.util;

import android.content.Context;
import android.content.SharedPreferences;


public class LocalStorage {


	
	public LocalStorage(Context ctx){
		context = ctx;
		fileName = "system";
	}
	public LocalStorage(Context ctx,String fileName){
		this.context = ctx;
		this.fileName = fileName;
	}
	
	public void putString(String key,String val){
		 SharedPreferences pref = context.getSharedPreferences(fileName, 0);
		 pref.edit().putString(key, val).commit();
	}
	
	public String getString(String key,String defVal){
		String val="";
		SharedPreferences pref = context.getSharedPreferences(fileName, 0);
		val = pref.getString(key, defVal);		
		return val;
	}
	
	public void putInt(String key ,int val){
		SharedPreferences pref = context.getSharedPreferences(fileName, 0);
		 pref.edit().putInt(key, val).commit();
	}
	
	public int getInt(String key,int defVal){
		int val=0;
		SharedPreferences pref = context.getSharedPreferences(fileName, 0);
		val = pref.getInt(key, defVal);		
		return val;
		
	}
	
	private Context context;
	private String  fileName;
}
