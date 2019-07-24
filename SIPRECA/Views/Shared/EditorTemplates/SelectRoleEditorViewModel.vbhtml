@ModelType SelectRoleEditorViewModel

@Html.HiddenFor(Function(Model) Model.RoleName)
<tr>
    <td class="form-group clearfix" style="text-align:center">
        @*@Html.CheckBoxFor(Function(Model) Model.Selected, New With {.class = "flat", .style = "position: absolute; opacity: 0;", .name = "item.RoleName"})*@
        @Html.CheckBoxFor(Function(m) m.Selected, New With {.style = "width: 19px; height: 19px; cursor: pointer; color: white; position: absolute; left: 2px; top: 2px; background: #fff; border: 1px solid #999; display: inline-block; position: relative; margin: 0 auto; float: left;"})
    </td>
    <td>
        @Html.DisplayFor(Function(m) m.RoleName, New With {.style = "color: white"})
    </td>
</tr>


@*<div class="form-group clearfix">

    @Html.CheckBoxFor(Function(m) m.RememberMe, New With {.style = "width: 19px; height: 19px; cursor: pointer; position: absolute; left: 2px; top: 2px; background: #fff; border: 1px solid #999; display: inline-block; position: relative; margin: 0 auto; float: left;"})
    &nbsp;&nbsp;
    @Html.LabelFor(Function(m) m.RememberMe)
</div>*@