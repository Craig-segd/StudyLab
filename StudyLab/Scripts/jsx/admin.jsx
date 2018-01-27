
var divStyle = {
    textAlign: "center",
    marginLeft: "5px"
};

class Button extends React.Component {

    HandleFrontButton() {
        window.location = "/home/index";
    }

    render() {
        return (           
            <button onClick={this.HandleFrontButton}className="btn btn-primary frontEndButton">Back to Frontend</button>

            );
    }
}


class NavbarLeft extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            activeButton: ""

        };

    }

    HandleClick = () => {

        this.setState({ activeButton: 5 });
        console.log(this.state.activeButton);
    }

    render() {
        return (
            <div className="list-group navLeft">
                <a href="#" className="list-group-item navItem active">
                    Home
                </a>
                <a href="#" className="list-group-item navItem">
                    Add Question
                </a>
                <a id={1} onClick={this.HandleClick} href="#" className="list-group-item navItem">Edit Question</a>
                <a id={2} onClick={this.HandleClick} href="#" className="list-group-item navItem">Question Data</a>
                <a id={3} onClick={this.HandleClick} href="#" className="list-group-item navItem">Statistics</a>
            </div>
        );
    }
}

var Panel = function (props) {
    return (
        <div className="panel panel-default panelCenter">
            <div className="panel-heading">{props.name}</div>
            <div className="panel-body">
                <App/>

            </div>
        </div>
    );
}

var AdminBody = function () {
    return (<div className="AdminContainer">
        <NavbarLeft/>
        <div className="content-container">
            <Panel name = "Add a Question"/>
            
            </div>
        </div>

    );
}

class AdminHome extends React.Component {

    render() {
        return (
            <div>
                <div className="nav-container">
                    Administration
                    <Button/>
                </div>
                <AdminBody />
            </div>
        );
    }

}

var DeleteButton = function () {
    return (
        <button onClick={DeleteHandler} className="btn btn-primary">Delete</button>
    );
}

var EditButton = function () {
    return (
        <button style={divStyle} onClick={EditHandler} className="btn btn-warning">Edit</button>
    );
}

function DeleteHandler() {
    console.log("hi");
}

function EditHandler() {
    console.log("hi");
}

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Questions: []
        }
    }

    componentDidMount() {
        fetch("api/questions")
            .then(result => result.json())
            .then(params => {
                this.setState({ Questions: params });
            });
    }

    render() {
        return (
            <table className="table table-bordered questionTable">
                <tbody>
                <tr>
                    <th style={{ backgroundColor: "#888" }}>Question</th>
                    <th style={{ backgroundColor: "#888" }}>Answer</th>
                    <th style={{ backgroundColor: "#888" }}>Type</th>
                    <th style={{ backgroundColor: "#888" }}>Delete</th>
                </tr>

                {this.state.Questions.map(function (object, i) {
                    return <tr key={i}>
                            <td>{object.QuestionText}</td>
                            <td>{object.AnswerText}</td>
                            <td>{object.TypeId}</td>
                            <td><DeleteButton /><EditButton /></td>
                        </tr>;
                })}

                </tbody>
            </table>
        );
    }
}

ReactDOM.render(<AdminHome />, document.getElementById("root"));
