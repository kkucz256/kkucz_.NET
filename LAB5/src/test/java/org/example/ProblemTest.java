package org.example;
import org.junit.jupiter.api.Test;
import java.util.List;
import static org.junit.jupiter.api.Assertions.*;

class ProblemTest {
    @Test
    void check_instance() {
        Problem problem = new Problem(10, 1, 1, 10);
        Result result = problem.Solve(11);
        int total_value_expected = 23;
        int total_weight_expected = 11;
        int count_expected = 3;
        assertEquals(total_weight_expected, result.getTotal_weight());
        assertEquals(total_value_expected, result.getTotal_value());
        assertEquals(count_expected, result.getCount());

    }

    @Test
    void check_if_empty(){
        Problem problem = new Problem(10, 1, 1, 10);
        Result result = problem.Solve(1);
        assertEquals(0, result.getCount());
    }

    @Test
    void check_if_one_fits(){
        Problem problem = new Problem(10, 1, 1, 10);
        Result result = problem.Solve(3);
        assertFalse(result.getItems().isEmpty());
    }

    @Test
    void check_if_in_range(){
        int lower_range = 1;
        int upper_range = 10;
        Problem problem = new Problem(10, 1, lower_range, upper_range);
        List<Item> items = problem.getItems();
        for (Item item : items) {
            int weight = item.getWeight();
            int value = item.getValue();
            assertTrue(weight >= lower_range && weight <= upper_range);
            assertTrue(value >= lower_range && value <= upper_range);
        }
    }

}