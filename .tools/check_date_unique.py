import argparse
import csv

def check_unique_dates(csv_file):
    unique_dates = set()
    duplicate_lines = []
    line_count = 0

    # Otwórz plik CSV
    with open(csv_file, 'r') as file:
        reader = csv.reader(file)
        header = next(reader)  # Pobierz nagłówek

        # Sprawdź wartości w kolumnie "Date"
        for row in reader:
            line_count += 1
            date = row[0]

            # Sprawdź, czy data jest unikalna
            if date in unique_dates:
                duplicate_lines.append(row)
            else:
                unique_dates.add(date)

    # Jeśli znaleziono zduplikowane linie, usuń je
    if duplicate_lines:
        with open(csv_file, 'w', newline='') as file:
            writer = csv.writer(file)
            writer.writerow(header)
            writer.writerows(duplicate_lines)

        print(f"Znaleziono {len(duplicate_lines)} zduplikowanych linii i usunięto je.")
    else:
        print("Wszystkie daty są unikalne.")

    print(f"Liczba przetworzonych linii: {line_count}")

# Parsowanie argumentów wiersza poleceń
parser = argparse.ArgumentParser(description='Check and remove duplicate lines based on the "Date" column in a CSV file.')
parser.add_argument('csv_file', help='Path to the CSV file')

# Przetwarzanie argumentów wiersza poleceń
args = parser.parse_args()

# Wywołaj funkcję check_unique_dates z podanym plikiem CSV
check_unique_dates(args.csv_file)
