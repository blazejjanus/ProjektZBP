import csv
import sys

def normalize_csv(input_file, output_file):
    with open(input_file, 'r') as file:
        reader = csv.reader(file, delimiter=',')
        rows = [row for row in reader if not row[0].startswith('#')]

    with open(output_file, 'w', newline='') as file:
        writer = csv.writer(file, delimiter=';')
        writer.writerows(rows)

    print(f"Normalized CSV file '{input_file}' and saved it as '{output_file}'.")

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print("Usage: python normalize_csv.py <input_file.csv> <output_file.csv>")
    else:
        input_file = sys.argv[1]
        output_file = sys.argv[2]
        normalize_csv(input_file, output_file)
