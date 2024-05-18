package org.example;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Random;

public class Problem {
    private final List<Item> items;

    public Problem(int number, int seed, int lower_range, int upper_range) {
        this.items = new ArrayList<>();

        Random random = new Random(seed);

        for (int i = 0; i < number; i++) {
            int value = lower_range + random.nextInt(upper_range - lower_range + 1);
            int weight = lower_range + random.nextInt(upper_range - lower_range + 1);

            Item item = new Item(value, weight);
            this.items.add(item);
        }
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        for (Item item : items) {
            String current = "Item id: " + item.getId() + ", item weight: " + item.getWeight() + ", item value: " + item.getValue() + "\n";
            output.append(current);
        }
        return output.toString();
    }

    public Result Solve(int capacity) {
        items.sort(Comparator.comparingDouble(Item::getRatio).reversed());

        List<Item> final_items = new ArrayList<>();
        int total_value = 0;
        int total_weight = 0;

        for (Item item : items) {
            while (total_weight + item.getWeight() <= capacity) {
                final_items.add(item);
                total_value += item.getValue();
                total_weight += item.getWeight();
            }
        }

        return new Result(final_items, total_weight, total_value);
    }

    public List<Item> getItems() {
        return items;
    }
}
