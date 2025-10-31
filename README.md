# DataSeeder - Test Data Generator

DataSeeder is a Blazor WebAssembly application that allows developers and testers to quickly generate realistic test data for development environments or local databases. The application uses configurable models and Liquid templates to customize data output.

## Features

- **Data Model Management**: Create, edit, and delete data models with custom fields
- **Multiple Field Types**: Support for strings, integers, decimals, booleans, dates, emails, names, addresses, and more
- **Realistic Data Generation**: Uses Bogus library to generate realistic fake data
- **Liquid Templates**: Customize output format using Liquid template syntax
- **Live Preview**: See generated data instantly with template rendering
- **Multiple Export Formats**: Export to CSV, JSON, or SQL
- **Local Storage**: Models and templates are saved locally in the browser
- **100% Client-Side**: No server required, runs entirely in the browser

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Running the Application

1. Clone this repository
2. Navigate to the project directory
3. Run the application:
   ```bash
   dotnet run
   ```
4. Open your browser to the displayed URL (typically `https://localhost:5001`)

### Building for Production

```bash
dotnet publish -c Release
```

The output will be in `bin/Release/net9.0/publish/wwwroot/` and can be deployed to any static web hosting service.

## Usage

### Creating a Data Model

1. Click "New Model" to create a new data model
2. Give your model a name
3. Set the number of rows to generate
4. Click "Add Field" to add fields to your model
5. For each field:
   - Enter a field name
   - Select a field type
   - Set any constraints (length, value ranges)
6. Click "Save Model" to save your work

### Generating Data

1. Select or create a model
2. Define a Liquid template (optional):
   - Use `{{ fieldName }}` to insert field values
   - Use `{% for item in items %}...{% endfor %}` to loop through all rows
   - Use `{% if %}` for conditional logic
3. Click "Generate" to create data
4. View the results in the preview panel

### Exporting Data

1. After generating data, use the "Export" dropdown to choose a format:
   - **CSV**: Comma-separated values
   - **JSON**: JSON array of objects
   - **SQL**: SQL INSERT statements
2. Or click "Copy" to copy the data to your clipboard

## Field Types

- **String**: Random text with optional length constraints
- **Integer**: Random integers with optional min/max values
- **Decimal**: Random decimal numbers with optional min/max values
- **Boolean**: Random true/false values
- **Date**: Random dates from the past 5 years
- **Email**: Realistic email addresses
- **FirstName**: Realistic first names
- **LastName**: Realistic last names
- **FullName**: Realistic full names
- **City**: City names
- **Country**: Country names
- **PhoneNumber**: Phone numbers
- **Address**: Full street addresses
- **UUID**: Universally unique identifiers
- **CompanyName**: Company names
- **JobTitle**: Job titles

## Technology Stack

- **Blazor WebAssembly**: Front-end framework
- **Bogus**: Realistic fake data generation
- **Fluid.Core**: Liquid template parsing and rendering
- **Blazored.LocalStorage**: Browser local storage persistence
- **Bootstrap 5**: UI framework
- **Bootstrap Icons**: Icon set

## Example Workflow

1. Create a model named "User" with fields:
   - `FirstName` (FirstName type)
   - `LastName` (LastName type)
   - `Email` (Email type)
   - `City` (City type)

2. Define a template:
   ```liquid
   {% for item in items %}
   {{ item.FirstName }} {{ item.LastName }} - {{ item.Email }} - {{ item.City }}
   {% endfor %}
   ```

3. Set row count to 100 and click "Generate"

4. Export the data to CSV or copy to clipboard

## License

This project is provided as-is for educational and development purposes.
