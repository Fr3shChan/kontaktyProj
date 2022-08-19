<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="rekrutacyjneZad.userProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <!-- Skrypt umożliwiający wyszukiwanie danego rekordu -->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Zarządzanie kontaktami</h4>
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="images/usericon.png" />
                                       
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>ID kontaktu</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Formularz kontaktu</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="imię"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="nazwisko"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="email"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="hasło"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="kategoria"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="podkategoria"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="numer tel"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="data urodzenia"></asp:TextBox>                                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>
            <div  class="col-md-20">
                <div   class="card">
                    <div  class="card-body">
                        <div   class="row">
                            <div class="col">
                                <center>
                                        <h4>Szczegółowa lista kontaktów</h4>
                                    </center>
                            </div>
                        </div>                      
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rekruDBConnectionString2 %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [contactTB]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="contact_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="contact_id" HeaderText="ID kontaktu" ReadOnly="True" SortExpression="contact_id" />
                                        <asp:BoundField DataField="contact_name" HeaderText="imię" SortExpression="contact_name" />
                                        <asp:BoundField DataField="contact_surname" HeaderText="nazwisko" SortExpression="contact_surname" />
                                        <asp:BoundField DataField="contact_email" HeaderText="email" SortExpression="contact_email" />
                                        <asp:BoundField DataField="contact_password" HeaderText="hasło" SortExpression="contact_password" />
                                        <asp:BoundField DataField="contact_category" HeaderText="kategoria" SortExpression="contact_category" />
                                        <asp:BoundField DataField="contact_undercategory" HeaderText="podkategoria" SortExpression="contact_undercategory" />
                                        <asp:BoundField DataField="contact_phone" HeaderText="numer tel" SortExpression="contact_phone" />
                                        <asp:BoundField DataField="contact_birthdate" HeaderText="data urodzenia" SortExpression="contact_birthdate" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>      
</asp:Content>
