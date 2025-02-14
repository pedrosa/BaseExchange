# Base Exchange - Technical Assessment  

This project consists of two applications communicating via **FIX 4.4** using **QuickFIX/N**:  

- **OrderGenerator**: A web-based order submission system.  
- **OrderAccumulator**: A backend system that processes orders and calculates financial exposure.  

## Technologies  

- **Backend**: C# (.NET 6+)  
- **Frontend**: React (or another chosen framework)  
- **Communication**: FIX 4.4 via QuickFIX/N  

## Features  

### OrderGenerator  
- Web form for order creation with fields:  
  - **Symbol**: PETR4, VALE3, or VIIA4  
  - **Side**: Buy or Sell  
  - **Quantity**: Positive integer (< 100,000)  
  - **Price**: Positive decimal (< 1,000, multiple of 0.01)  
- Sends orders via FIX and displays the response.  

### OrderAccumulator  
- Computes **financial exposure** per symbol:  
  \[
  Exposure=∑(price×executedquantity) buys −∑(price×executedquantity)sells
  \]  
- Rejects orders exceeding **R$ 100,000,000** exposure.  
- Responds with an **ExecutionReport**:  
  - **New** (order accepted and included in calculations)  
  - **Rejected** (order ignored)  

## Installation and Execution  

1. **Clone the repository**  
   ```sh
   git clone https://github.com/your-username/your-repository.git  
   cd your-repository  
   ```  

2. **Set up the environment**  
   - Install **.NET 6+** and configure **QuickFIX/N**.  
   - Adjust FIX connection settings in QuickFIX/N config files.  

3. **Run OrderAccumulator**  
   ```sh
   dotnet run --project OrderAccumulator  
   ```  

4. **Run OrderGenerator**  
   ```sh
   dotnet run --project OrderGenerator  
   ```  

5. **Access the frontend**  
   Open `http://localhost:3000` in a browser.
## References  

- [QuickFIX/N](https://quickfixn.org/)  
- [FIX Protocol](https://www.fixtrading.org/standards/)  
