import sys
import pandas as pd

def polacz_pliki_csv(plik1, plik2, plik_wynikowy):
    # Wczytaj dane z plików CSV
    df1 = pd.read_csv(plik1)
    df2 = pd.read_csv(plik2)
    
    # Połącz pliki na podstawie wspólnej kolumny (data)
    polaczony_df = pd.merge(df1, df2, on='data', how='inner')
    
    # Zapisz połączone dane do nowego pliku CSV
    polaczony_df.to_csv(plik_wynikowy, index=False)
    
    print("Pliki zostały połączone. Wynik zapisano w pliku", plik_wynikowy)

# Sprawdzenie poprawności liczby argumentów
if len(sys.argv) != 4:
    print("Podano niepoprawną liczbę argumentów.")
    print("Użycie: python join_csv.py plik1.csv plik2.csv plik_wynikowy.csv")
    sys.exit(1)

# Pobranie ścieżek do plików z argumentów wiersza poleceń
plik1 = sys.argv[1]
plik2 = sys.argv[2]
plik_wynikowy = sys.argv[3]

polacz_pliki_csv(plik1, plik2, plik_wynikowy)
