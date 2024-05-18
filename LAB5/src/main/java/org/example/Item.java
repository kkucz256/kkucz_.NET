package org.example;

public class Item {
    private final int value;
    private final int weight;
    private final double ratio;
    static int count = 0;
    private final int id;

    public Item(int value, int weight) {
        this.value = value;
        this.weight = weight;
        this.ratio = calculateRatio();
        id = count++;
    }



    public double calculateRatio(){
        double ratio = (double)this.value/this.weight;
        return ratio;
    }
    public int getValue() {return value;}
    public int getWeight() {return weight;}
    public double getRatio() {return ratio;}
    public int getId() {return id;}
}
