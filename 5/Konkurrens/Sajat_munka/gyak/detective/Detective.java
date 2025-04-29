import java.util.concurrent.BlockingQueue;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicInteger;

/**
 * A detektivek eloszor kihallgatjak a bunozoket, majd, ha eleg informaciot
 * sikerult
 * szerezniuk, akkor letartoztatjak a nagyobb szintu bunozoket.
 * Amikor egy detektiv nem tud senkit kihallgatni, akkor elmegy kaveszunetre,
 * majd folytatja.
 */
public class Detective {
    private static final int COFFEE_DRINKING_TIME_MSEC = 500;
    private static final int PERP_WAITING_TIME_MSEC = 100;
    private static final int PERP_INTERROGATION_TIME_MSEC = 500;
    private static final int DETECTIVE_PREPARATION_TIME_MSEC = 1000;
    private final String name;

    public Detective(final String name) {
        this.name = name;
    }

    /**
     * Egy detektiv folyamatosan kihallgatja a bunozoket, egeszen addig, amig eleg
     * bizonyitek all rendelkezesukre.
     * Ha epp nincs bunozo, akit ki tudna hallgatni, akkor elmegy kaveszunetre.
     * Amikor a detektivek kollektivan eleg informaciot szereztek, akkor abbahagyjak
     * a kihallgatas/kaveszunet
     * ciklust, es a nagyobb bunozok eletere tornek.
     *
     * @param perpQueue Sor, ahonnan lekerdezik a bunozoket
     */
    public synchronized void interrogate(BlockingQueue<Perpetrator> perpQueue, AtomicInteger detectiveFinished,
            Object flag) {
        Perpetrator perp = null;
        while (SharedInformation.getInstance().isGatheringInformation()) {
            // TODO 1. Resz: Probaljunk kiszedni a queue-bol egy bunozot, de adjuk fel
            // $PERP_WAITING_TIME_MSEC msec utan
            try {
                perp = perpQueue.poll(PERP_WAITING_TIME_MSEC, TimeUnit.MILLISECONDS);
            } catch (InterruptedException e) {
            }
            // TODO 1. Resz: Amennyiben nem sikerult talalnunk bunozot, hivjuk meg a
            // drinkCoffee() metodust, majd probaljuk ujra
            if (perp == null)
                drinkCoffee();
            // TODO 1. Resz: Amennyiben talaltunk egy bunozot, hivjuk meg az
            // interrogatePerp(perp) metodust
            else
                interrogatePerp(perp);
        }

        System.out.println(this.name + " finished interrogation");
        System.out.println(this.name + " gets ready to catch crime bosses");

        // TODO 2. Resz: Varjunk $DETECTIVE_PREPARATION_TIME_MSEC msec-et

        try {
            Thread.sleep(DETECTIVE_PREPARATION_TIME_MSEC);
        } catch (InterruptedException e) {
        }

        // TODO 2. Resz: Jelezzuk, hogy a detektiv kesz arra, hogy elkapja a tobbi
        // bunozot
        detectiveFinished.incrementAndGet();
        synchronized (flag) {
            flag.notifyAll();
        }
        // TODO 2. Resz: Tipp: Hozza tudsz adni uj parametert a fuggvenyhez
    }

    /**
     * A detektiv $COFFEE_DRINKING_TIME_MSEC ideig elmegy kaveszunetre
     */
    private synchronized void drinkCoffee() {
        System.out.println(name + " is drinking coffee");
        // TODO 1. Resz: Varjunk $COFFEE_DRINKING_TIME_MSEC msec-et
        try {
            Thread.sleep(COFFEE_DRINKING_TIME_MSEC);
        } catch (InterruptedException e) {
        }
        System.out.println(name + " finished drinking coffee");
    }

    /**
     * A detektiv kihallgatja az elkovetot, aki ad valamennyi informaciot
     * $PERP_INTERROGATION_TIME_MSEC msec eltelte utan
     * 
     * @param perp
     */
    private synchronized void interrogatePerp(final Perpetrator perp) {
        System.out.println(name + " is interrogating " + perp);
        // TODO 1. Resz: Varjunk $PERP_INTERROGATION_TIME_MSEC msec-et
        try {
            Thread.sleep(PERP_INTERROGATION_TIME_MSEC);
        } catch (InterruptedException e) {
        }
        SharedInformation.getInstance().addNewInformation(perp.interrogationResult());
    }
}