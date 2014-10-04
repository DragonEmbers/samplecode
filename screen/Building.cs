class Building : Tile
{
	public virtual double z {get; protected set;}
	public virtual double height {get; protected set;}
	
	public Building()
	{
	}
	
	// setting functions
	public void setZ(double sz)
	{
		z = sz;
	}
	
	public void setHeight(double h)
	{
		height = h;
	}
	
	// getting functions
	public string getDimensions()
	{
		return length + " x " + width + " x " + height;
	}
	public string getCoords()
	{
		return "x=" + x + " y=" + y + " z=" + z;
	}
	
	public void draw()
	{
		// draw object to screen
	}
}
