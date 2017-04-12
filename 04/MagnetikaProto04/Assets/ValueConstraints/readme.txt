Value Constraints Version 1.0.0 11/29/2015

GENERAL USAGE NOTES
==============================================
Constrains values (int’s, float’s) between a range.
Ping pong between a range as a desired speed or scale.
Wrap up or down between a range as a desired speed or scale.
Randomize between a range.
Use one of the Limit Types provided as a class field.
Add Property Attribute to the field.
Use the Property Attribute constructor to customize display and functionality.
Supports undo/redo.

INSTALLATION
==============================================
Down the package from Unity Asset Store
Import all the assets
In the script with the field to protect, add the [ValueBounds] attribute to that field derived from type Limit.
Additionally use [ValueBounds()] to set defaults and display options.
ValueBounds() is the lowest level class provided


EXAMPLE
==============================================
The example show the highest level classes ValueVector2 and ValueVector3 to move, scale and rotate a scene GameObject.  The example uses one of the pre-made components Position2DBehaviour  and Position3DBehaviour to oscillate a cubes transform properties.

----------------------------------------------

[ValueVector]
public ValuePosition2D value = new ValuePosition2D(0.0f, 1.0f, 0.5f, 1, 0.1f, ActionType.PingPong);

public ValueControlFloat[] valueVectors;

----------------------------------------------

Another EXAMPLE of usage.

[ValueVector]
[SerializeField]
ValuePosition2D m_ValueVector;

void Update()
{
	Vector3 position = transform.position;
	m_ValueVector.DoAction(out position, Time.deltaTime);
	transform.position = position;
}
----------------------------------------------

CONTACT
==============================================
Developer: caLLowCreation
Author: Jones S. Cropper
E-mail: callowcreation@gmail.com 
Subject: ValueConstraints
Website: www.caLLowCreation.com