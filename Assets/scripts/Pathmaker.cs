﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================
// put this script on a Sphere... it will move around, and drop a path of floor tiles behind it


public class Pathmaker : MonoBehaviour {

    public float counter;
    public float randomnum;
    public GameObject spherePrefab;
    public GameObject floorPrefab;

    public Vector3 currentPos;
    public Vector3 rotation;

    public static int tilecount;
 


    // STEP 2: ============================================================================================
    // translate the pseudocode below

    //	DECLARE CLASS MEMBER VARIABLES:
    //	Declare a private integer called counter that starts at 0; 		// counter var will track how many floor tiles I've instantiated
    //	Declare a public Transform called floorPrefab, assign the prefab in inspector;
    //	Declare a public Transform called pathmakerSpherePrefab, assign the prefab in inspector; 		// you'll have to make a "pathmakerSphere" prefab later


    void Update () {
        //		If counter is less than 50, then:
        //			Generate a random number from 0.0f to 1.0f;
        //			If random number is less than 0.25f, then rotate myself 90 degrees;
        //				... Else if number is 0.25f-0.5f, then rotate myself -90 degrees;
        //				... Else if number is 0.99f-1.0f, then instantiate a pathmakerSpherePrefab clone at my current position;
        //			// end elseIf

        //			Instantiate a floorPrefab clone at current position;
        //			Move forward ("forward", as in, the direction I'm currently facing) by 5 units;
        //			Increment counter;
        //		Else:
        //			Destroy my game object; 		// self destruct if I've made enough tiles already


        //STEP 2
        currentPos = transform.position;

        if (counter < 50)
        {
            randomnum = Random.Range(0.00f, 1.00f);

            if (randomnum < 0.25f) {

                rotation = new Vector3(rotation.x, rotation.y + 90, rotation.z);
                transform.rotation = Quaternion.Euler(rotation);
               // transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }

            else if (0.25f<=randomnum&&randomnum<=0.50f)
            {
                rotation = new Vector3(rotation.x, rotation.y - 90, rotation.z);
                transform.rotation = Quaternion.Euler(rotation);
                // transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }                   
            else if (0.90f <= randomnum && randomnum <= 1.00f)
            {
                GameObject newSphere = Instantiate(spherePrefab, currentPos, Quaternion.identity);
            }

            GameObject newfloor = Instantiate(floorPrefab, currentPos, Quaternion.identity);
            tilecount++;
            transform.position+=(transform.rotation* Vector3.forward * 5);
           

            counter++;

        }
        else
        {
            Destroy(gameObject);
        }

        //STEP 3

        if (tilecount > 9999)
        {
            Destroy(gameObject);
        }

       
    }

} // end of class scope

// MORE STEPS BELOW!!!........




// STEP 3: =====================================================================================
// implement, test, and stabilize the system

//	IMPLEMENT AND TEST:
//	- save your scene!!! the code could potentially be infinite / exponential, and crash Unity
//	- put Pathmaker.cs on a sphere, configure all the prefabs in the Inspector, and test it to make sure it works
//	STABILIZE: 
//	- code it so that all the Pathmakers can only spawn a grand total of 500 tiles in the entire world; how would you do that?
//          - hint 1: a "static" variable is like a global variable, there's only 1 instance of that variable shared across the entire game / all objects
//	    - hint 2: declare a "public static int" counter, increment each time you instantiate a floor tile... like "globalTileCount++"
//          - hint 3: if there are already too many tiles, then self-destruct without spawning new floor tiles... like "if(globalTileCount > 500)" ... "Destroy(gameObject);"
//          - note: a static var will persist beyond scene changes! you have to reset the variable manually!


// STEP 4: ======================================================================================
// tune your values...

// a. how long should a pathmaker live? etc.
// b. how would you tune the probabilities to generate lots of long hallways? does it work?
// c. tweak all the probabilities that you want... what % chance is there for a pathmaker to make a pathmaker? is that too high or too low?



// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass

// - move the game camera to a position high in the world, and then point it down, so we can see your world get generated
// - CHANGE THE DEFAULT UNITY COLORS, PLEASE, I'M BEGGING YOU
// - add more detail to your original floorTile placeholder -- and let it randomly pick one of 3 different floorTile models, etc. so for example, it could randomly pick a "normal" floor tile, or a cactus, or a rock, or a skull
//		- MODEL 3 DIFFERENT TILES IN MAYA! DON'T STOP USING MAYA OR YOU'LL FORGET IT ALL
//		- add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]



// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
