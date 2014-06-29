package com.example.onlineschedule.adapter;

import android.content.Context;
import android.graphics.Color;
import android.view.View;
import android.view.ViewGroup;
import android.widget.SimpleAdapter;

import java.util.List;
import java.util.Map;

/**
 * Created with IntelliJ IDEA.
 * User: rft
 * Date: 13-2-14
 * Time: 上午9:04
 * To change this template use File | Settings | File Templates.
 */
public class MySimpleAdapter extends SimpleAdapter {
    public MySimpleAdapter(Context context, List<? extends Map<String, ?>> data, int resource, String[] from, int[] to) {
        super(context, data, resource, from, to);
    }

    /**
     * 获取当前选中行索引
     *
     * @return
     */
    public int getSelectedIndex() {
        return selectedIndex;
    }

    /**
     * 设置当前选中行索引
     *
     * @param selectedIndex
     */
    public void setSelectedIndex(int selectedIndex) {
        this.selectedIndex = selectedIndex;
    }

    protected int selectedIndex;

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View localView = super.getView(position, convertView, parent);
        if (position == selectedIndex) {
            localView.setBackgroundColor(Color.BLUE);
            ;
        } else {
            localView.setBackgroundColor(Color.WHITE);
        }

        return localView;
    }
}
