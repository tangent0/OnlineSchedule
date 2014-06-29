package com.example.onlineschedule.util;

import android.util.Log;

import com.example.onlineschedule.entity.Remind;
import com.example.onlineschedule.entity.Schedule;

import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserFactory;

import java.io.StringReader;
import java.util.ArrayList;

/**
 * Created with IntelliJ IDEA.
 * User: rft
 * Date: 13-2-27
 * Time: 上午11:51
 * To change this template use File | Settings | File Templates.
 */
public class XmlScheduleParser {
    //<?xml version="1.0"?><AppStore><app id="1"><Name>MyChat</Name><Path>/专题</Path><Desc>LV</Desc><DownloadTimes>0</DownloadTimes></app><app id="2"><Name>360market</Name><Path>/专题</Path><Desc>love</Desc><DownloadTimes>0</DownloadTimes></app></AppStore>
    private static final String ns = null;

    public XmlScheduleParser() {

    }

    public static ArrayList<Schedule> Parse(String strXmlDoc) {
        ArrayList<Schedule> list = new ArrayList<Schedule>();
        try {
            XmlPullParserFactory factory = XmlPullParserFactory.newInstance();
            //定义解析器 XmlPullParser
            XmlPullParser parser = factory.newPullParser();
            //获取xml输入数据
            parser.setInput(new StringReader(strXmlDoc));
            //开始解析事件
            int eventType = parser.getEventType();
            //处理事件，不碰到文档结束就一直处理

            Schedule obj = null;
            while (eventType != XmlPullParser.END_DOCUMENT) {
                String tagName;
                if (eventType == XmlPullParser.START_TAG) {
                    tagName = parser.getName();
                    if (tagName.equalsIgnoreCase("item")) {
                        obj = new Schedule();
                        obj.week = parser.getAttributeValue(ns, "week");
                    } else if (obj != null) {
                        tagName = parser.getName();
                        if (tagName.equalsIgnoreCase("Section")) {
                            obj.section = parser.nextText();
                        } else if (tagName.equalsIgnoreCase("Course")) {
                            obj.course = parser.nextText();
                        } else if (tagName.equalsIgnoreCase("Addr")) {
                            obj.address = parser.nextText();
                        } else if (tagName.equalsIgnoreCase("Teacher")) {
                            obj.teacher = parser.nextText();
                        } else if (tagName.equalsIgnoreCase("week")) {
                            obj.week = parser.nextText();
                        }
                    }
                } else if (eventType == XmlPullParser.END_TAG) {
                    tagName = parser.getName();
                    if (tagName.equalsIgnoreCase("item")) {
                        if (obj != null) {
                            list.add(obj);
                        }
                        obj = null;
                    }
                }
                eventType = parser.next();
            }
        } catch (Exception ex) {
            Log.e("XmlParser", ex.getMessage(), ex);
        }
        return list;
    }
    public static ArrayList<Remind> ParseRemind(String strXmlDoc) {
        ArrayList<Remind> list = new ArrayList<Remind>();
        try {
            XmlPullParserFactory factory = XmlPullParserFactory.newInstance();
            //定义解析器 XmlPullParser
            XmlPullParser parser = factory.newPullParser();
            //获取xml输入数据
            parser.setInput(new StringReader(strXmlDoc));
            //开始解析事件
            int eventType = parser.getEventType();
            //处理事件，不碰到文档结束就一直处理

            Remind obj = null;
            String str;
            while (eventType != XmlPullParser.END_DOCUMENT) {
                String tagName;
                if (eventType == XmlPullParser.START_TAG) {
                    tagName = parser.getName();
                    if (tagName.equalsIgnoreCase("item")) {
                        obj = new Remind();
                        //str = parser.getAttributeValue(ns, "Id");
                        //obj.Id = Integer.parseInt(str); //parser.getAttributeValue(ns, "Id");
                    } else if (obj != null) {
                        tagName = parser.getName();
                        if (tagName.equalsIgnoreCase("Id")) {
                        	str = parser.nextText();
                            obj.Id = Integer.parseInt(str);
                        } else if (tagName.equalsIgnoreCase("Note")) {
                            obj.Note = parser.nextText();
                        } else if (tagName.equalsIgnoreCase("Month")) {
                        	str = parser.nextText();
                            obj.Month = Integer.parseInt(str);
                        } else if (tagName.equalsIgnoreCase("Day")) {
                        	str = parser.nextText();
                            obj.Day = Integer.parseInt( str );
                        } 
                    }
                } else if (eventType == XmlPullParser.END_TAG) {
                    tagName = parser.getName();
                    if (tagName.equalsIgnoreCase("item")) {
                        if (obj != null) {
                            list.add(obj);
                        }
                        obj = null;
                    }
                }
                eventType = parser.next();
            }
        } catch (Exception ex) {
            Log.e("XmlParser", ex.getMessage(), ex);
        }
        return list;
    }
}
