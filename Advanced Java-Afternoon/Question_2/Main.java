package com.company;

import org.dom4j.*;
import java.sql.*;
import java.io.File;
import java.util.*;
import org.dom4j.io.SAXReader;


class Student
{
	//Connection Object
	Connection con;

    Student()
    {
        try{
			//JDBC Connector has been used
            Class.forName("com.mysql.cj.jdbc.Driver");
			//Make necessary changes as per your system's schema, port, username and password
            con=DriverManager.getConnection("jdbc:mysql://localhost:3306/student","root","amalik");
			
        }catch(Exception e)
        {
            System.out.println(e.getMessage());
        }
    }

	//Function for adding a new row in Student Table
	
    public void addRow(int RollNo, String FirstName, String MiddleName, String LastName,String Gender, float Marks)
    {
        try {

            PreparedStatement stmt = con.prepareStatement("insert into student values (?,?,?,?,?)");
            stmt.setInt(1, RollNo);
            stmt.setString(2, FirstName+" "+MiddleName);
            stmt.setString(3, LastName);
            stmt.setString(4, Gender);
            stmt.setFloat(5, Marks);
            if(stmt.executeUpdate()>0)
                System.out.println("Student Record Inserted\n");
            else
                System.out.println("Insertion Failed");

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

	//Function for printing all rows of the Student Table
	
    public void printTableData()
    {
        try {
            Statement stmt = con.createStatement();
            ResultSet datatset =  stmt.executeQuery("select * from student");
            while (datatset.next()) {
                System.out.print(datatset.getInt("id")+"\t");
                System.out.print(datatset.getString("Name")+"\t");
                System.out.print(datatset.getString("Surname")+"\t");
                System.out.print(datatset.getString("Gender")+"\t");
                System.out.println(datatset.getFloat("Marks")+"\t");
            }

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public void close()
    {
        try{
            con.close();
        }catch(Exception er)
        {
            System.out.println(er.getMessage());
        }
    }

}


public class Main {

    public static void main(String[] args)  {


        // New Database Object
		Student obj =  new Student();
        
		String FirstName=null,MiddleName=null,LastName=null,Gender=null;
        int RollNo=0;
        float Marks=0;
        try{
			
		// Extracting Data from XML File	
        // Make necessary changes to the path
		
		//==========================XML PARSING==========================
		File xmlfile = new File("A:\\input.txt");
        SAXReader saxReader = new SAXReader();
        Document document = saxReader.read(xmlfile);
        List<Node> nodes = document.selectNodes("/class/student");

        for (Node node : nodes) {
            RollNo = Integer.parseInt(node.valueOf("@rollno"));
            FirstName = node.selectSingleNode("name/firstname").getText();
            MiddleName = node.selectSingleNode("name/middlename").getText();
            LastName = node.selectSingleNode("name/lastname").getText();
            Gender = node.selectSingleNode("gender").getText();
            Marks = Float.parseFloat(node.selectSingleNode("marks").getText());
        }
		
		//==================================================================
		
		
            System.out.println("Student Table before insertion of record from the given XML file\n");
            obj.printTableData();
			// Adding data from XML file to Student Table
            obj.addRow(RollNo,FirstName,MiddleName,LastName,Gender,Marks);
            //System.out.println(Marks);
            System.out.println("Student Table after insertion of the record from the given XML file\n");
            obj.printTableData();
			
			
            }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }
        finally
        {
            obj.close();
        }


    }
}
