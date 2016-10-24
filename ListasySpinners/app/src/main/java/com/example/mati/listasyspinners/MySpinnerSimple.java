package com.example.mati.listasyspinners;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

public class MySpinnerSimple extends AppCompatActivity {
    Spinner miSpinner;
    final static String semana[]={"lunes","martes","miercoles","jueves","viernes","sabado","domingo"};
    @Override

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_spinner_simple);

        String mensaje;
        miSpinner = (Spinner) findViewById(R.id.spinner1);
        ArrayAdapter<String> miAdaptador = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_dropdown_item, semana);
        miAdaptador.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        miSpinner.setAdapter(miAdaptador);

        miSpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener(){
            public void onItemSelected(AdapterView arg0, View arg1, int position, long id){
                String mensaje = "";
                mensaje = "Item clicked => "+semana[position];
                showToast(mensaje);
            }
            public void onNothingSelected(AdapterView<?> adapterView){
                }
        });

        }
    public void showToast(String text){
        Toast.makeText(this, text, Toast.LENGTH_SHORT).show();}
}
