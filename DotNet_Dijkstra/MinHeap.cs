namespace Classes;

public class MinHeap<T> where T: IComparable<T>{
    Dictionary<T, int> positionTable = new Dictionary<T, int>();

    List<T> minHeap;
    private int size;

    public MinHeap(){ //constructor for the heap
        this.minHeap = new List<T>();
        this.size = 0;
    }

    public int getPositon(T item){ //gets the position of a specific item
        return positionTable[item];    
    }

    public bool isEmpty(){ //checks if the que is empty
        return size <= 0;
    }

    private int Parent(int pos){ //gets the parent of a position
        return (pos - 1)/2;
    }
    private int leftChild(int pos){ //gets the left child of a position
        return pos * 2 + 1;
    }
    private int rightChild(int pos){//gets the right child of a position
        return pos * 2 + 2;
    }

    private void swap(int pos1, int pos2){ //swaps 2 elements around
        T dummy = minHeap[pos1];

        minHeap[pos1] = minHeap[pos2];
        minHeap[pos2] = dummy;
    }

    public void Insert(T item){ //adds an item to the que
        minHeap.Add(item);
        positionTable.Add(item, size);
        size++;
        decreaseKey(size - 1);
    }

    public void decreaseKey(int pos){ //compares the position to the parrent if it have higher priority it swaps the pos with the parent
        int currentpos = pos;
        while (minHeap[currentpos].CompareTo(minHeap[Parent(currentpos)]) < 0){ 
            swap(currentpos, Parent(currentpos));
            currentpos = Parent(currentpos);
        }
    }
    public T viewMin(){ //returns the current first object in the que
        return minHeap[0];
    }

    private bool movedown(int pos){ //returns true if any child is higher priority than the current pos
        bool leftsmaller = leftChild(pos) < size 
            && (minHeap[leftChild(pos)].CompareTo(minHeap[pos])<0);
        bool rightsmaller = rightChild(pos) < size 
            && (minHeap[rightChild(pos)].CompareTo(minHeap[pos])<0);
        return leftsmaller || rightsmaller;
    }

    public void increaseKey(int pos){ //while any child is lower swaps the current pos with a child
        int currentpos = pos;
        while(movedown(currentpos)){
            int rpos = rightChild(currentpos);
            int lpos = leftChild(currentpos);

            if(rpos < size && minHeap[rpos].CompareTo(minHeap[lpos]) < 0 ){ //if the right child is lower swap with it
                swap(rpos, currentpos);
                currentpos = rpos;
            } else{ //if the right pos isnt lower swap with the left one
                swap(lpos, currentpos);
                currentpos = lpos;
            }
        }
    }

    public T extractMin(){ //removes the first object in the que
        T min = minHeap[0];

        minHeap[0] = minHeap[size - 1];
        positionTable.Remove(min);
        //positionTable.Add(minHeap[0], 0);
        size--;
        increaseKey(0);
        return min;
    }

}