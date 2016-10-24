package com.example.mati.listasyspinners;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {
Button btnBoton1, btnBoton2, btnBoton3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initialUIsetp();

    btnBoton1.setOnClickListener(new View.OnClickListener(){
        public void onClick(View v){
            Intent miIntent= new Intent(MainActivity.this,myListaSimple.class);
            startActivity(miIntent);
        }
    });
   btnBoton2.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                Intent miIntent= new Intent(MainActivity.this,MySpinnerSimple.class);
                startActivity(miIntent);
            }
        });
        btnBoton3.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                Intent miIntent= new Intent(MainActivity.this,myListaObjetos.class);
                startActivity(miIntent);
            }
        });


    }
    public  void initialUIsetp(){
        btnBoton1  = (Button) findViewById(R.id.btnBoton1);
        btnBoton2  = (Button) findViewById(R.id.btnBoton2);
        btnBoton3 = (Button) findViewById(R.id.btnBoton3);

    }


}
