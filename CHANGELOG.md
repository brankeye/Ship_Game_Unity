# CHANGELOG #

### CURRENT VERSION ###

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

* v1.2.5 - Wednesday, July 16, 2014
* added block types: Quad, various Triangles, and a Half Circle.
* Operational Tools: Work Tool, Zoom Tool, Type Tool, Color Tool, View Tool.
* Upcoming Tools: Rotate Tool, History Tool.
* can use various shapes in the Ship Editor, cannot rotate blocks yet, coming next.
* efficiency improvements to loading blocks, there is now one list containing a Block class with type, position, and color as opposed to separate lists.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

### PAST VERSIONS ###

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

* v1.2.2 - Tuesday, July 15, 2014
* efficiency improvements in the way the Ship Editor, Tool Handler, and various tools work.
* the position of a block placed in the Ship Editor is now determined mathematically using the mouse position and the current ship object scale.
  * much more efficient this way, previous method was VERY bulky.
* blocks added in the Ship Editor do not cause the whole ship to be redrawn, they are simply added individually -as of an earlier version-.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

* v1.2.1 - Monday, July 14, 2014
* added new Zoom Tool for the Ship Editor.
* ships in the Ship Display now scale properly.
* ships in the Ship Editor are by default scaled 1:1, the user is in control of zooming.
* blocks cannot be added in the Ship Editor if a tool is in use.
* added two new panels to the Ship Editor, the panels cover the ship just below the UI controls.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

* v1.2.0 - Tuesday, July 13, 2014
* user can now edit any ship, and add as many blocks as they want.
* user can choose color of new blocks to add to a ship.
* user can cancel editing of a ship and revert changes.
* user CANNOT delete/overwrite blocks.
* user can move the camera view of the ship by dragging in any direction in the Ship Editor.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

* v1.1.0 - Wednesday, July 02, 2014
* can create new ships of user selected color.
* new ships are saved automatically.
* upon creation of a new ship, it is automatically switched to as the current active ship.
* can scroll between all user ships in the SHIPS screen.
* user cannot play until at least one ship has been created.
* many UI bugs fixed, such as buttons being clickable from other screens.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

* v1.0.0 - Wednesday, June 25, 2014
* basic UI navigation almost complete.
* very basic gameplay demo playable.
* able to save data and have it persist between plays.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------