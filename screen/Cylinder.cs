using System;
class Cylinder
{
	private double height;
	private double radius;
	private double diameter;
	private double volume;
	
	public Cylinder()
	{
	}
	
	// setting functions
	public void setDimensions(double h, double d)
	{
		height = h;
		diameter = d;
	}
	
	// getting functions
	public string getDimensions()
	{
		return height + " x " + diameter;
	}
	public double getVolume()
	{
		radius = diameter / 2;
		return radius * radius * Math.PI * height;
	}
}
