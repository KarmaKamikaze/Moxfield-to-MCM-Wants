# Moxfield-to-MCM-Wants
**Moxfield-to-MCM-Wants** is a utility that bridges the gap between the Moxfield decklists and Cardmarket (MCM) Wants lists. If you’re a Magic: The Gathering enthusiast who uses Moxfield to manage your decklists and also wants to keep your Wants list up-to-date on MCM, this tool can help automate the process.

## Features
- Fetches Magic: The Gathering decklists from Moxfield.
- Creates a new Wants list on MCM using the Moxfield deck name.
- Uploads the decklist to your new MCM Wants list.

## How It Works
1. **Decklist Retrieval:** The application uses Selenium to scrape decklists from Moxfield. 
2. **Wants List Creation:** Once the decklist is retrieved, the application creates a new Wants list on MCM. The list is named after the corresponding Moxfield deck.
3. **Upload to MCM:** The decklist is then uploaded to the newly created MCM Wants list using Selenium. This ensures that your desired cards are tracked on MCM. Since the MCM API is not yet publicly accessible, this manual automation approach ensures that the process can be carried out seamlessly.

## Installation
1. Clone this repository to your local machine.
2. Make sure you have the latest version of **Selenium WebDriver** and **Google Chrome** installed.
3. Set up your Moxfield and MCM accounts.
4. Configure the necessary parameters (e.g., WebDriver Directory, MCM credentials) in the application's `appsettings.json`.

## Usage
1. Run the application.
2. Provide the Moxfield deck URL.
3. The application will fetch the decklist and create a new Wants list on MCM.
4. Cards from the Moxfield deck will be added to the MCM Wants list.

## Future Improvements
As the MCM API becomes available to the public, a refactor is necessary for the application to directly interact with the API. This would eliminate the need for manual steps and enhance the overall user experience.

## Contributing
Contributions are welcome! Feel free to open issues or submit pull requests.

## License
This project is licensed under the MIT License - see the `LICENSE` file for details.
