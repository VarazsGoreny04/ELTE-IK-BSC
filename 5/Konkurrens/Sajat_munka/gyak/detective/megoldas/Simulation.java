
import java.sql.SQLOutput;
import java.util.List;
import java.util.concurrent.*;
import java.util.concurrent.atomic.AtomicInteger;

/**
 * Ebben a szimulacioban nehany detektiv a brooklyni 99. korzetbol ki fog hallgatni nehany bunozot,
 * annak erdekeben, hogy informaciot szerezzenek a feletteseikrol. Mikor kozosen sikerult az osszes
 * lehetseges informaciot megszerezniuk errol a bunos organizaciorol, egyutt megprobaljak letartoztatni
 * a tobbi bunozot.
 */
public class Simulation {
    private static final int NUMBER_OF_ADDITIONAL_THREADS = 2;
    private static final int PERP_PRODUCER_WAIT_TIME_MSEC = 100;
    private static final int PERP_QUEUE_LIMIT = 5;

    private static final List<Detective> detectives = List.of(
        new Detective("Jake"),
        new Detective("Amy"),
        new Detective("Charles"),
        new Detective("Rosa"),
        new Detective("Terry"),
        new Detective("Hitchcock"),
        new Detective("Scully")
    );

    // TODO 1. Resz: Hozzuk letre detectives.size() merettel
    private static final ExecutorService detectiveExecutor = Executors.newFixedThreadPool(detectives.size());
    // TODO 1. Resz: Hozzuk letre NUMBER_OF_ADDITIONAL_THREADS merettel
    private static final ExecutorService executionExecutor = Executors.newFixedThreadPool(NUMBER_OF_ADDITIONAL_THREADS);
    // TODO 1. Resz: Hozzuk letre PERP_QUEUE_LIMIT limittel
    private static final BlockingQueue<Perpetrator> perpQueue = new ArrayBlockingQueue<>(PERP_QUEUE_LIMIT);
    // TODO 2. Resz: Csinaljunk egy valtozot, amivel nyomon kovetjuk,hogy vege van-e a szimulacionak, vagy nem (simulationOver)
    // TODO 2. Resz: simulationOver = false

    /**
     * 1. Inditsunk uj szalat, amivel letrehozzuk a bunozoket (producePerpetrator)
     * 2. Inditsunk uj szalat, amivel elkaphatjuk a tobbi bunozot (catchCrimeBosses)
     * 3. Minden detektivnek inditsuk el a kihallgatasi (interrogation) metodusat
     * 4. Varjunk, amig a szimulacionak vege
     * 5. Menjunk biztosra, hogy a program terminal
     */
    public static void main(String[] args) {
        // TODO 1. Resz: Inditsuk el a producePerpetrator muveletet egy kulon szalon az executionExecutor hasznalataval

        executionExecutor.submit(() -> {Simulation.producePerpetrator();});

        // TODO 2. Resz: Inditsuk el a catchCrimeBosses muveletet egy kulon szalon az executionExecutor hasznalataval

        // TODO 1. Resz: Inditsuk el minden detektivnek az interrogate muveletet a detectiveExecutor hasznalataval

        detectives.forEach(detective -> {detectiveExecutor.submit( () -> {detective.interrogate(perpQueue);} );});

        // TODO 1. Resz: Varjunk 20 masodpercet (kommenteljuk ki a masodik reszre)

        try {
            Thread.sleep(20000);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }

        // TODO 2. Resz: Varjunk, amig vege a szimulacionak (az 1. resz idozitett varakozasa helyett)

        // TODO 1. Resz: Gyozodjunk meg rola, hogy a programunk leall
    }

    /**
     * Letrehoz egy uj bunozot minden $PERP_PRODUCER_WAIT_TIME_MSEC idokozonkent - ha egy
     * uj bunozo nem fer bele a queue-ba, akkor maskor lesz kihallgatva (nem foglalkozunk vele)
     */
    private static void producePerpetrator() {
        AtomicInteger counter = new AtomicInteger(0);
        while(SharedInformation.getInstance().isGatheringInformation()) {
            Perpetrator perp = new Perpetrator(counter.getAndIncrement());
            synchronized(perpQueue) {
                if(perpQueue.remainingCapacity() > 0 ) {
                    // TODO 1. Resz: Adjuk hozza a perp-et a queue-hoz, ha tudjuk, majd logoljuk
                    // TODO System.out.println(perp + " is ready to be interrogated");
                    perpQueue.add(perp);
                    System.out.println(perp + " is ready to be interrogated");
                }else{
                    // TODO 1. Resz: Ha a queue teli van, logoljuk
                    // TODO System.out.println(perp + " will be interrogated another day");
                    System.out.println(perp + " will be interrogated another day");
                }
            }

            // TODO 1. Resz: Varjunk $PERP_PRODUCER_WAIT_TIME_MSEC msec-et

            try {
                Thread.sleep(PERP_PRODUCER_WAIT_TIME_MSEC);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }

        }
    }

    /**
     * Varjunk, amig a detektivek megszerzik a szukseges informaciot, majd elkapjak a tobbi bunozot.
     * Ha elkaptak oket, a szimulacio leall.
     */
    private static void catchCrimeBosses() {
        // TODO 2. Resz: Varjunk, amig az osszes informaciot megszereztek a detektivek, es mindegyik keszen all

        System.out.println("The detectives caught the crime bosses!");

        // TODO 2. Resz: Allitsuk igazra a simulationOver erteket
        // TODO 2. Resz: Jelezzuk, hogy vege van a szimulacionak
    }

}
