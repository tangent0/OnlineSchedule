package com.example.onlineschedule.util;

import java.util.ArrayList;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.text.format.Time;
import android.util.Log;
import android.widget.TextView;

import com.example.onlineschedule.entity.Remind;

public class DBHelper extends SQLiteOpenHelper {
    private final static String DATABASE_NAME = "todo_db";
    private final static int DATABASE_VERSION = 3;

    private final String REMIND_TABLE = "remind";
    private final String SCHEDULE_TABLE = "todo_schedule";

    public final String FIELD_id = "_id";
/*
    public final String REMIND_TV = "todo_remind";
    public final String REMIND_TIME = "todo_remind_time";
    public final String REMIND_TIME_ID = "todo_remind_timeId";
    */

    public final String SCHEDULE_WEEK = "todo_week";
    public final String SCHEDULE_TV1 = "todo_section";
    public final String SCHEDULE_TV2 = "todo_course";
    public final String SCHEDULE_TV3 = "todo_add";

    private static final String DIARY_TABLE_CREATE = "create table diaries (_id integer primary key autoincrement, "
            + "event_type integer not null,content text not null,hour integer not null,minute integer not null,"
            + "date text not null,rate integer);";
    private static final String REMIND_TABLE_CREATE = "create table remind(_id integer primary key,"
    		+ "note text, mon integer,day integer)";

//  public SQLiteDatabase db;


    public DBHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);

    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // TODO Auto-generated method stub
    /* 建立table */
        String sql = "";
        /*
        sql = "CREATE TABLE "
                + REMIND_TABLE
                + " ("
                + FIELD_id + " INTEGER primary key autoincrement, "
                + REMIND_TV + " text, "
                + REMIND_TIME + " text, "
                + REMIND_TIME_ID + " text "
                + " )";

        db.execSQL(sql);
        
        db.execSQL(DIARY_TABLE_CREATE);
        */
        db.execSQL(REMIND_TABLE_CREATE);
        
        sql = "CREATE TABLE "
                + SCHEDULE_TABLE
                + " ("
                + FIELD_id + " INTEGER primary key autoincrement, " + " "
                + SCHEDULE_WEEK + " text, "
                + SCHEDULE_TV1 + " text, "
                + SCHEDULE_TV2 + " text, "
                + SCHEDULE_TV3 + " text )";
        Log.i("DBHelper", "sql2代码如下:" + sql);
        db.execSQL(sql);
        try {

            db.execSQL("drop table todo_schedule");
            db.execSQL("create table if not exists todo_schedule(_id int primary key,todo_week int,todo_section int,todo_course varchar,todo_add varchar)");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(1,1,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(2,1,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(3,1,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(4,1,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(5,1,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(6,2,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(7,2,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(8,2,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(9,2,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(10,2,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(11,3,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(12,3,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(13,3,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(14,3,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(15,3,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(16,4,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(17,4,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(18,4,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(19,4,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(20,4,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(21,5,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(22,5,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(23,5,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(24,5,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(25,5,5,'','')");
                    /*db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(26,6,1,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(27,6,2,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(28,6,3,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(29,6,4,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(30,6,5,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(31,7,1,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(32,7,2,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(33,7,3,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(34,7,4,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(35,7,5,'空','空','空')");*/


            Log.i("", "已初始化数据库");

        } catch (Exception e) {
            // TODO: handle exception
        }
    }
    public void clearSchedule()
    {
    	SQLiteDatabase db = this.getWritableDatabase();
        try {

            db.execSQL("drop table todo_schedule");
            db.execSQL("create table if not exists todo_schedule(_id int primary key,todo_week int,todo_section int,todo_course varchar,todo_add varchar)");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(1,1,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(2,1,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(3,1,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(4,1,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(5,1,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(6,2,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(7,2,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(8,2,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(9,2,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(10,2,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(11,3,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(12,3,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(13,3,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(14,3,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(15,3,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(16,4,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(17,4,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(18,4,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(19,4,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(20,4,5,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(21,5,1,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(22,5,2,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(23,5,3,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(24,5,4,'','')");
            db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(25,5,5,'','')");
                    /*db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(26,6,1,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(27,6,2,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(28,6,3,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(29,6,4,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(30,6,5,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(31,7,1,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(32,7,2,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(33,7,3,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(34,7,4,'空','空','空')");
    				db.execSQL("insert into todo_schedule(_id,todo_week,todo_section,todo_course,todo_add) values(35,7,5,'空','空','空')");*/


            Log.i("", "已初始化数据库");

        } catch (Exception e) {
            // TODO: handle exception
        }
    	
    }

    //  @Override
//  public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
//  {
//    String sql = "DROP TABLE IF EXISTS "
//      + REMIND_TABLE;
//    db.execSQL(sql);
//      onCreate(db);
//      }
    public ArrayList<Remind> selectRemind() {
    	ArrayList<Remind> list = new ArrayList<Remind>();
        SQLiteDatabase db = this.getReadableDatabase();
        String orderBy = " mon desc";
        Cursor cursor = db.query(REMIND_TABLE, null, null, null, null, null, orderBy);
        while(cursor.moveToNext())
        {
        	Remind obj = new Remind();
        	obj.Id = cursor.getInt(cursor.getColumnIndex("_id"));
        	obj.Note = cursor.getString(cursor.getColumnIndex("note"));
        	obj.Month = cursor.getInt(cursor.getColumnIndex("mon"));
        	obj.Day = cursor.getInt(cursor.getColumnIndex("day"));
        	list.add(obj);        	
        	
        }
        return list;
    }

    public long insertRemind(int id,String note, int month,int day) {
        SQLiteDatabase db = this.getWritableDatabase();
    /* 将新增的值放入ContentValues */
        ContentValues cv = new ContentValues();
        cv.put("_id", id);
        cv.put("note", note);
        cv.put("mon", month);
        cv.put("day", day);
        long row = db.insert("Remind", null, cv);

        return row;
    }

    public void delete(int id, String table) {
        SQLiteDatabase db = this.getWritableDatabase();
        String where = FIELD_id + " = ?";
        String[] whereValue = {Integer.toString(id)};
        db.delete(table, where, whereValue);
    }
    public void deleteAll(String table)
    {
    	SQLiteDatabase db = this.getWritableDatabase();
        //String where = FIELD_id + " = ?";
        //String[] whereValue = {Integer.toString(id)};
        db.delete(table, null, null);
    }
    


    public void updateRemind(int id, String note, int month, int day) {
        SQLiteDatabase db = this.getWritableDatabase();
        String where = FIELD_id + " = ?";
        String[] whereValue = {Integer.toString(id)};
    /* 将修改的值放入ContentValues */
        ContentValues cv = new ContentValues();
        cv.put("note", note);
        cv.put("mon", month);
        cv.put("day", day);
        db.update("remind", cv, where, whereValue);
    }

    public void updateCourse(int id, String text) {

        SQLiteDatabase db = this.getWritableDatabase();
        String where = FIELD_id + " = ?";
        String[] whereValue = {Integer.toString(id)};
    /* 将修改的值放入ContentValues */
        ContentValues cv = new ContentValues();
        cv.put(SCHEDULE_TV2, text);
        db.update(SCHEDULE_TABLE, cv, where, whereValue);
    }

    public void updateAdd(int id, String text) {
        SQLiteDatabase db = this.getWritableDatabase();
        String where = FIELD_id + " = ?";
        String[] whereValue = {Integer.toString(id)};
    /* 将修改的值放入ContentValues */
        ContentValues cv = new ContentValues();
        cv.put(SCHEDULE_TV3, text);
        db.update(SCHEDULE_TABLE, cv, where, whereValue);
    }
    public void updateCourse(String week,String section,String course,String addr){
        SQLiteDatabase db = this.getWritableDatabase();
        String where =  " todo_week = ? and todo_section=?";
        String[] whereValue = {week,section};
    /* 将修改的值放入ContentValues */
        ContentValues cv = new ContentValues();
        cv.put(SCHEDULE_TV2, course);
        cv.put(SCHEDULE_TV3, addr);
        db.update(SCHEDULE_TABLE, cv, where, whereValue);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // TODO Auto-generated method stub

    }
}