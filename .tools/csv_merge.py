import argparse
import csv

def merge_csv_files(input_file1, input_file2, output_file):
    # Wczytanie danych z pierwszego pliku CSV
    data1 = {}
    with open(input_file1, 'r') as file1:
        reader = csv.reader(file1)
        header1 = next(reader)  # Pobranie nagłówka
        for row in reader:
            date = row[0]
            values = row[1:]
            data1[date] = values

    # Wczytanie danych z drugiego pliku CSV
    data2 = {}
    with open(input_file2, 'r') as file2:
        reader = csv.reader(file2)
        header2 = next(reader)  # Pobranie nagłówka
        for row in reader:
            date = row[0]
            values = row[1:]
            data2[date] = values

    # Połączenie nagłówków kolumn
    merged_header = header1 + header2[1:]

    # Połączenie danych
    merged_data = []
    for date in sorted(data1.keys()):
        if date in data2:
            merged_row = [date] + data1[date] + data2[date]
            merged_data.append(merged_row)

    # Zapisanie danych do pliku wynikowego
    with open(output_file, 'w', newline='') as output:
        writer = csv.writer(output)
        writer.writerow(merged_header)
        writer.writerows(merged_data)

# Parsowanie argumentów wiersza poleceń
parser = argparse.ArgumentParser(description='Merge two CSV files.')
parser.add_argument('input_file1', help='First input CSV file')
parser.add_argument('input_file2', help='Second input CSV file')
parser.add_argument('output_file', help='Output CSV file')

# Przetwarzanie argumentów wiersza poleceń
args = parser.parse_args()

# Wywołanie funkcji merge_csv_files z przekazanymi argumentami
merge_csv_files(args.input_file1, args.input_file2, args.output_file)
