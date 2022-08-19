<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="rekrutacyjneZad.userLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="images/usericon.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Użytkownik</h3>          
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                </hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Login</label>
                                <div class="for-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeHolder="Login">
                                    </asp:TextBox>
                                </div>
                                <h3></h3>
                                <label>Hasło</label>
                                <div class="for-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeHolder="Hasło" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                                <div class="for-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="homePage.aspx">Strona Główna</a>
            </div>
        </div>
    </div>
</asp:Content>
