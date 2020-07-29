package com.company;


import java.io.File;
import java.sql.*;
import java.util.*;
// For XML parsing
import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Node;
import org.dom4j.io.SAXReader;

class Student
{
    //Connection Object
    Connection con;

    //Constructor
    Student()
    {
        try{
            //JDBC Connector has been used
            Class.forName("com.mysql.cj.jdbc.Driver");
            //Make necessary changes as per your system's schema, port, username and password
            con= DriverManager.getConnection("jdbc:mysql://localhost:3306/student","root","amalik");
        }
        catch(Exception e) {
            System.out.println(e.getMessage());
        }
    }

    //Function for adding a new row in Student Table
    public void AddRow(int RollNo, String FirstName, String MiddleName, String LastName,String Gender, float Marks)
    {
        try {
            PreparedStatement stmt = con.prepareStatement("insert into student values (?,?,?,?,?)");
            stmt.setInt(1, RollNo);
            stmt.setString(2, FirstName+ " "+ MiddleName);
            stmt.setString(3, LastName);
            stmt.setString(4, Gender);
            stmt.setFloat(5, Marks);
            if(stmt.executeUpdate()>0)
                System.out.println("Student Record Inserted\n");
            else
                System.out.println("Insertion Failed");

        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    //Function for printing all rows of the Student Table
    public void ViewStudentTable()
    {
        try {
            Statement s = con.createStatement();
            ResultSet DataSet =  s.executeQuery("select * from student");
            while (DataSet.next()) {
                System.out.print(DataSet.getInt("id")+"\t");
                System.out.print(DataSet.getString("Name")+"\t");
                System.out.print(DataSet.getString("Surname")+"\t");
                System.out.print(DataSet.getString("Gender")+"\t");
                System.out.println(DataSet.getFloat("Marks")+"\t");
            }
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public void close()
    {
        try{
            con.close();
        }
        catch(Exception e) {
            System.out.println(e.getMessage());
        }
    }

}


public class Main {


    private static void ParseXML(Student obj) throws DocumentException
    {

        String FirstName=null,MiddleName=null,LastName=null,Gender=null;
        int RollNo=0;
        float Marks=0;
        //==========================XML PARSING==========================

        // Make necessary changes to the path
        File XMLFile = new File("A:\\input.txt");
        SAXReader Sax = new SAXReader();
        Document Doc = Sax.read(XMLFile);
        List<Node> nodes = Doc.selectNodes("/class/student");

        for (Node node : nodes) {
            RollNo = Integer.parseInt(node.valueOf("@rollno"));
            FirstName = node.selectSingleNode("name/firstname").getText();
            MiddleName = node.selectSingleNode("name/middlename").getText();
            LastName = node.selectSingleNode("name/lastname").getText();
            Gender = node.selectSingleNode("gender").getText();
            Marks = Float.parseFloat(node.selectSingleNode("marks").getText());
        }
        //==================================================================

        // Adding data from XML file to Student Table
        obj.AddRow(RollNo,FirstName,MiddleName,LastName,Gender,Marks);
    }


    public static void main(String[] args)
    {

        // New Database Object
        Student obj =  new Student();
        try{

            System.out.println("Student Table before insertion of record from the given XML file\n");
            obj.ViewStudentTable();

            // Parsing input.txt and adding its content to Student Table
            ParseXML(obj);

            System.out.println("Student Table after insertion of the record from the given XML file\n");
            obj.ViewStudentTable();
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }
        finally {
            obj.close();
        }

    }
}
