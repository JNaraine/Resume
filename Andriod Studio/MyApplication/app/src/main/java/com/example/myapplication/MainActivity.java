package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;


import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    //initialize variables
    private EditText UserName;
    private EditText Password;
    private Button btn;

    //username and password login
    private String Username = "user";
    private String password = "1234";

    boolean isValid = false;
    private int counter = 3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        UserName =  findViewById(R.id.UserName);
        Password =  findViewById(R.id.Password);
        btn = findViewById(R.id.btn);


        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String inputName = UserName.getText().toString();
                String inputPassword = Password.getText().toString();

                //Error if user put in wrong information
                if( inputName.isEmpty() || inputPassword.isEmpty()){
                    Toast.makeText(MainActivity.this, "Incorrect Username or Password", Toast.LENGTH_SHORT).show();
                }else{


                    isValid = validate(inputName, inputPassword);

                    if(!isValid){
                        counter--;

                        Toast.makeText(MainActivity.this, "Error",Toast.LENGTH_SHORT).show();

                        if(counter == 0){
                            btn.setEnabled(false);
                        }
                    }else{

                        //to confirm that the login was successful
                        Toast.makeText(MainActivity.this, "Login Successful",Toast.LENGTH_SHORT).show();

                        //redirect to another class
                        Intent intent = new Intent (MainActivity.this, Welcome.class);
                        startActivity(intent);
                    }

                }
            }
        });



    }

    //indicate if the login was successful or not
    private boolean validate(String name, String pass){
        if(name.equals(Username)&& pass.equals(password)){
            return true;
        }
        return false;
    }



}