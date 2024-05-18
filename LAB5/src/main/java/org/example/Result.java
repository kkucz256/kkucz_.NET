package org.example;
import java.util.ArrayList;
import java.util.List;

public class Result {
    private final List<Item> final_items;
    private final int total_weight;
    private final int total_value;
    private final int count;

    Result(List<Item> list_of_items, int total_weight, int total_value)
    {
        this.total_weight = total_weight;
        this.total_value = total_value;
        this.count = list_of_items.size();
        this.final_items = new ArrayList<>();
        this.final_items.addAll(list_of_items);
    }

    @Override
    public String toString(){
        StringBuilder output = new StringBuilder();
        for(Item item : this.final_items){
            String current = "Item id: " + item.getId() + ", item weight: " + item.getWeight() + ", item value: " + item.getValue()+"\n";
            output.append(current);
        }
        output.append("Total weight: " + this.total_weight + ", Total value: " + this.total_value +", Count: " + this.count);
        return output.toString();
    }
    public int getTotal_weight() {return total_weight;}
    public int getTotal_value() {return total_value;}
    public int getCount() {return count;}
    public List<Item> getItems() { return final_items;}
}
