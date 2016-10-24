package com.example.mati.listasyspinners;

import android.app.Activity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class myListaObjetos extends AppCompatActivity {

    private Titular[]datos = new Titular[]{
            new Titular("Piratas del Caribe","La maldicion de la Perla Negra",R.drawable.caratula1),new Titular("Piratas del Caribe","El cofre del hombre Muerto",R.drawable.caratula2),
            new Titular("Piratas del Caribe","En el fin del mundo",R.drawable.caratula3)
    };


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_lista_objetos);

        AdaptadorTitulares adaptador = new AdaptadorTitulares(this);
        ListView lstOpciones = (ListView)findViewById(R.id.LstOpciones);

        lstOpciones.setAdapter(adaptador);

        lstOpciones.setOnItemClickListener(new AdapterView.OnItemClickListener(){
            public void onItemClick(AdapterView arg0, View arg1, int position, long id){
                String mensaje = "Titulo: " + datos[position].getTitulo1() + ". Subtitulo: "+datos[position].getSubtitulo()+null;
                Toast.makeText(getApplicationContext(),mensaje, Toast.LENGTH_LONG).show();

            }
            public void onNothingSelected(AdapterView<?> adapterView){

            }
        });



    }
    class AdaptadorTitulares extends ArrayAdapter{
        Activity context;
        AdaptadorTitulares(Activity context)
        {
            super(context, R.layout.listitem_titular, datos);
            this.context = context;
        }
        public View getView(int i, View convertView, ViewGroup parent){
            View view = convertView;
            if ( view == null) {
                LayoutInflater inflater = context.getLayoutInflater();
                view  = inflater.inflate(R.layout.listitem_titular, null);
            }

            TextView lblTitulo = (TextView) view.findViewById(R.id.tvTitulo);
            lblTitulo.setText(datos[i].getTitulo1());

            TextView lblSubtitulo = (TextView) view.findViewById(R.id.tvSubtitulo);
            lblSubtitulo.setText(datos[i].getSubtitulo());


            ImageView lblImagen = (ImageView) view.findViewById(R.id.imView);
            lblImagen.setImageResource(datos[i].getImagen());
            return (view);

        }
    }
}
