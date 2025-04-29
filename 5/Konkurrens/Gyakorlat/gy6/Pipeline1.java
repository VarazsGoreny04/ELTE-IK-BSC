import java.util.List;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

public class Pipeline1 {
    public static void main(String[] args) throws Exception {
        var NO_FURTHER_INPUT1 = "";
        var NO_FURTHER_INPUT2 = -1;

        var bq1 = new ArrayBlockingQueue<String>(1024);
        var bq2 = new ArrayBlockingQueue<Integer>(1024);

        var pool = Executors.newCachedThreadPool();

        pool.submit(() -> {
            bq1.addAll(List.of("a", "bb", "ccccccc", "ddd", "eeee", NO_FURTHER_INPUT1));
        });

        pool.submit(() -> {
            try {
                while (true) {
                    String elem = bq1.take();
                    if (elem == NO_FURTHER_INPUT1) {

                        bq2.put(NO_FURTHER_INPUT2);
                        break;
                    } else
                        bq2.put(elem.length());
                }
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        pool.submit(() -> {
            try {
                while (true) {
                    int elem = bq2.take();
                    if (elem == NO_FURTHER_INPUT2)
                        break;
                    else
                        System.out.println(elem);
                }
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        });

        pool.shutdown();
        pool.awaitTermination(10, TimeUnit.SECONDS);
    }
}
