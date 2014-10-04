class Tile
{
	public virtual double x {get; protected set;}
	public virtual double y {get; protected set;}
	
	public virtual double length {get; protected set;}
	public virtual double width {get; protected set;}
	
	public virtual string texture {get; protected set;}
	
	public virtual bool isSolid {get; protected set;}
	
	public Tile()
	{
		setXY(0,0);
		setDimensions(0,0);
		setTexture("");
		setSolid(false);
	}
	
	// setting functions
	public void setXY(double sx, double sy)
	{
		x = sx;
		y = sy;
	}
	
	public void setDimensions(double l, double w)
	{
		length = l;
		width = w;
	}
	
	public void setTexture(string t)
	{
		texture = t;
	}
	
	public void setSolid(bool s)
	{
		isSolid = s;
	}
	
	// getting functions
	public string getDimensions()
	{
		return length + " x " + width;
	}
	
	public string getCoords()
	{
		return "x=" + x + " y=" + y;
	}
	
	public bool isPassable()
	{
		return !isSolid;
	}
	
	public void draw()
	{
		// draw object to screen
	}
}
