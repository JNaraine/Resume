#include <iostream>
#include<string>
#include <stack>

using namespace std;

// the transaction class
class Transaction
{
public: 
	int amount;
	string tType;
	
	Transaction(int a, string t)
	{
		amount = a;
		tType = t;
	}
};

// the customer class
class Customer
{
public: // properties
	string name;
	int balance;
	//  using vector because a user cant make 1 transaction
	// can withrawal, and deposit
	Transaction* transaction;

	// initializ member data using the constructor
	Customer(string n, int b)
	{
		name = n;
		balance = b;
		transaction = NULL;
	}

	// here is the methode to process transactions
	void process(Transaction* t)
	{
		// check the type of transaction
		// if deposit add to balannce and deduct if withrawal
		transaction = t;
		if (transaction->tType == "deposit")
		{
			balance += transaction->amount;
			cout << "Deposited " << transaction->amount << " to " << name << " balance: " << balance << endl << endl;
		}
		else if (transaction->tType == "withdrawal")
		{
			if (transaction->amount < balance)
			{
				balance -= transaction->amount;
				cout << "withdrawal of " << transaction->amount << " from " << name << " balance: " << balance << endl << endl;
			}
			else cout << "Faild to withdraw " << transaction->amount << " from " << name << " balance: " << balance << endl << endl;
		}
	}
};


int main()
{
	// Empty stack
	stack<Customer> cStack;

	// Consider the folowing transactions
	Transaction d = Transaction(500, "deposit"); //deposit
	Transaction w = Transaction(1000, "withdrawal"); //withdrawal

	// adding customers to the stack
	cStack.push(Customer("Kevin", 500));
	cStack.push(Customer("Stephen", 1000));
	cStack.push(Customer("LeBron", 600));
	cStack.push(Customer("Candace", 200));
	cStack.push(Customer("Luka", 2000));
	cStack.push(Customer("Klay", 67));


	// processing the customers: deposit
	int i = 0; // the counter
	cout << "-----------------------------------------" << endl;
	while (!cStack.empty()) {
		Customer c = cStack.top();
		// withraw deposit
		i == 2 || i == 4 ? c.process(&w) : c.process(&d); // this line withraws when counter is 2 or 4 and deposits for the rest
		// After every five customers are processed, display the size of the stack and the name of the customer who will be served next.
		if (i % 5 == 0)
		{
			cout << "-----------------------------------------" << endl;
			int size = cStack.size();
			cout << "Size of the stack: " << size << endl;
			cout << "Next customer: " << cStack.top().name << endl;
			cout << "-----------------------------------------" << endl;
		}
		cStack.pop();
		i++;
	}
	cout << "-----------------------------------------" << endl;
	return 0;
}
