import csv
import sys

def fill_empty_cells(input_file, column_title):
    with open(input_file, 'r') as file:
        reader = csv.reader(file, delimiter=';')
        rows = [row for row in reader]

        # Find the index of the specified column title
        title_row = rows[0]
        column_index = title_row.index(column_title)

        # Iterate over the rows, starting from the second row
        for i in range(1, len(rows)):
            row = rows[i]
            if not row[column_index]:
                row[column_index] = rows[i - 1][column_index]

    with open(input_file, 'w', newline='') as file:
        writer = csv.writer(file, delimiter=';')
        writer.writerows(rows)

    print(f"Filled empty cells in column '{column_title}' of '{input_file}'.")

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print("Usage: python fill_empty_cells.py <input_file.csv> <column_title>")
    else:
        input_file = sys.argv[1]
        column_title = sys.argv[2]
        fill_empty_cells(input_file, column_title)
