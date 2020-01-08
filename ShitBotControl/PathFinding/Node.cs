using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitBotControl.PathFinding
{
    public class Node
    {
        //node states
        public enum State
        {
            DORMANT,    //node has not been awoken yet
            WAKING_UP,  //node will be awake next iteration
            ALIVE,      //node is awake and awakes other nodes
            DEATH       //node has been weighted in the route
        }

        //we need to save the node state
        public State currentState;

        //we need to save the connections between the crossroads
        public Node n_up, n_left, n_down, n_right;

        //the distance from the starting point
        public int weight;

        //is node enabled
        public bool isEnabled;

        //constructor for a isolated node
        public Node(bool isEnabled)
        {
            currentState = State.DORMANT;
            weight = -1;
            this.isEnabled = isEnabled;
        }

        //constructor for a node with connections
        public Node(bool isEnabled, Node n_up, Node n_left, Node n_down, Node n_right)
        {
            currentState = State.DORMANT;
            this.n_up = n_up;
            this.n_left = n_left;
            this.n_down = n_down;
            this.n_right = n_right;
            weight = -1;
            this.isEnabled = isEnabled;
        }

        //update the node
        public void Update()
        {
            //check if the node is awake
            if(currentState == State.ALIVE)
            {
                //if we have node left
                if (n_left != null)
                {
                    //wake node up
                    n_left.currentState = State.WAKING_UP;
                    //set node weight
                    n_left.weight = weight + 1;
                }

                //if we have node down
                if (n_down != null)
                {
                    //wake node up
                    n_down.currentState = State.WAKING_UP;
                    //set node weight
                    n_down.weight = weight + 1;
                }

                //if we have node right
                if (n_right != null)
                {
                    //wake node right
                    n_right.currentState = State.WAKING_UP;
                    //set node weight
                    n_right.weight = weight + 1;
                }

                //if we have a node up
                if (n_up != null)
                {
                    //wake node up
                    n_up.currentState = State.WAKING_UP;
                    //set node weight
                    n_up.weight = weight + 1;
                }
            }
        }

        
        
        
    }
}
