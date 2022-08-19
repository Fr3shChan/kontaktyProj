<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="rekrutacyjneZad.homePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div>
        <div class="col-sm-12">
            <center>
                <h3>
                    Podstawowe dane kontaktów
                </h3>
                </center>           
            <div class="row">
                <div class="col-sm-18 col-md-12">
                    <asp:Panel class="alert alert-success" role="alert" ID="Panel1"
                        runat="server" Visible="false">
                        <asp:Label ID="Labe1" runat="server" Text="Label1"></asp:Label>
                    </asp:Panel>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rekruDBConnectionString %>" SelectCommand="SELECT * FROM [contactTB]"></asp:SqlDataSource>
                                    <div class="col">
                                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="contact_id" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="contact_id" HeaderText="ID" ReadOnly="True" SortExpression="contact_id">
                                                    <ControlStyle Font-Bold="True" />
                                                    <ItemStyle Font-Bold="True" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-lg-14">
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("contact_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("contact_undercategory") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>   
                                                                        </div>         
                                                                    </div>     
                                                                    </div>   
                                                                </div>                                                                                                 </div>                       
                                                        </ItemTemplate>                                                                                      
                                                    </asp:TemplateField>
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
