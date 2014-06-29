package com.example.onlineschedule.entity;

/**
 * Created by Administrator on 14-5-1.
 */
public class MapNode {
    public MapNode(){
        latitude = 0.0;
        longitude = 0.0;
    }
    public MapNode(String nam){
        latitude = 0.0;
        longitude = 0.0;
        this.name= nam;
    }
    public MapNode(String nam,double toLatitude,double toLongitude){
        latitude = toLatitude;
        longitude = toLongitude;
        this.name= nam;
    }
    public double distance(double toLatitude,double toLongitude){
        double dist = 0;
        double toLati = toLatitude;
        double toLong = toLongitude;
        toLati *= 1000;
        toLong *= 1000;
        double srcLatitude = this.latitude * 1000;
        double srcLongitude = this.longitude * 1000;
        dist =  (toLati - srcLatitude) * (toLati - srcLatitude) + (toLong - srcLongitude) * (toLong - srcLongitude);
        //dist = Math.sqrt(dist);
        return dist;
    }

    @Override
    public String toString(){
        return name;
    }
    public String name;
    public double latitude;     //γ��
    public double longitude;    //����


}
