package com.example.onlineschedule.util;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import com.example.onlineschedule.R;


public class MessageBox {
	
	public MessageBox(){
		
	}
	public static void ShowMessageBox(Context context,String caption,String title){
		AlertDialog.Builder alertDialog = new AlertDialog.Builder(context)
		.setTitle(title)
		.setMessage(caption);
		alertDialog.setPositiveButton(R.string.ok,new OnClickListener(){

			public void onClick(DialogInterface dialog, int which) {
				
			}

		});
		alertDialog.show();
	}
	
	public static String InputString(Context ctx,String caption,String title){
		
		LayoutInflater factory = LayoutInflater.from(ctx);
		View v = factory.inflate(R.layout.input_number_dlg, null);
		final EditText inputEdit = (EditText)v.findViewById(R.id.etInputNum);
		inputEdit.setInputType(android.text.InputType.TYPE_CLASS_TEXT);
		
		AlertDialog.Builder alertDialog = new AlertDialog.Builder(ctx)
		.setTitle(title)
		.setMessage(caption);
		alertDialog.setPositiveButton(R.string.ok,new OnClickListener(){

			public void onClick(DialogInterface dialog, int which) {
				
			}

		});
		alertDialog.show();
		String strInput = "";
		strInput = inputEdit.getText().toString();		
		return strInput;
		
	}

}
