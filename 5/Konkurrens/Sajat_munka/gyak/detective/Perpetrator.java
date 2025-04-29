import java.util.concurrent.ThreadLocalRandom;

/**
 * A bunozoket reprezentalja, akiket ki fognak hallgatni a detektivek
 * informacioert a feletteseikrol.
 * Vagy nem mondanak semmit, vagy keveset.
 * Meg van egy egyedi azonositojuk is.
 */
public class Perpetrator {
    private static final int MINIMUM_INFORMATION_PERCENT = 0;
    private static final int MAXIMUM_INFORMATION_PERCENT = 3;
    private final int id;

    public Perpetrator(int id) {
        // TODO 1. Resz: Legyen egyedi azonositojuk, 0-tol indulva, egyessevel novekedve
        this.id = id;
    }

    /**
     * Jelzi, hogy milyen hasznos infot adott a bunozo
     * 
     * @return Az egesz info valahany szazaleka
     */
    public int interrogationResult() {
        // TODO 1. Resz: Adjunk vissza $MINIMUM_INFORMATION_PERCENT es
        // $MAXIMUM_INFORMATION_PERCENT kozott egy random erteket
        //Random rnd = new Random();
        ThreadLocalRandom rnd = ThreadLocalRandom.current();

        return rnd.nextInt(MINIMUM_INFORMATION_PERCENT, MAXIMUM_INFORMATION_PERCENT);
    }

    @Override
    public String toString() {
        return "Perpetrator #" + this.id;
    }
}
