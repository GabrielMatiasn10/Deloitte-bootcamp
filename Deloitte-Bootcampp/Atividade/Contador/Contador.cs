public class Contador {
    private static int _valor;

    public Contador() {
        _valor++;
    }

    public static void Zerar() => _valor = 0;
    public static int ObterValor() => _valor;
}

public static class ConversaoDeUnidadesDeArea {
    public static double MetroParaPe(double metro) => metro * 10.7639104;
    public static double PeParaMetro(double pe) => pe / 10.7639104;
}