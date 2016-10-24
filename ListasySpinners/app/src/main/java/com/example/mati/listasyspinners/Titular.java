package com.example.mati.listasyspinners;

/**
 * Created by mati on 17/10/16.
 */

public class Titular {

    private String titulo1, subtitulo;
    private int imagen;

    public Titular(String titulo1, String subtitulo) {
        this.titulo1 = titulo1;
        this.subtitulo = subtitulo;
    }
    public Titular(String titulo1, String subtitulo, int imagen) {
        this.titulo1 = titulo1;
        this.subtitulo = subtitulo;
        this.imagen = imagen;
    }



    public String getTitulo1() {
        return titulo1;
    }

    public void setTitulo1(String titulo1) {
        this.titulo1 = titulo1;
    }

    public String getSubtitulo() {
        return subtitulo;
    }

    public void setSubtitulo(String subtitulo) {
        this.subtitulo = subtitulo;
    }

    public int getImagen(){
        return imagen;
    }
    public void setImagen(int imagen){
        this.imagen = imagen;
    }


}
