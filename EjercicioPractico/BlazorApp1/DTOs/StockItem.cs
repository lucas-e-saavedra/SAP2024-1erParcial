﻿namespace BlazorApp1.DTOs
{
    public class StockItem
    {
        public Producto producto { get; set; }
        public int cantidad { get; set; }

        public override string ToString()
        {
            return cantidad + " x " + producto.Nombre;
        }
    }
}
