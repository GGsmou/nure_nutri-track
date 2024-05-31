import { Button } from "@mui/material";
import { Link } from "react-router-dom";
import { UserContext } from "./Fallback";
import { useContext } from "react";
import { useLogout } from "../features/useLogout";

export const Nav = () => {
  const user = useContext(UserContext);
  const isAdmin = user.role === "admin";
  const { mutateAsync: logout } = useLogout();

  return (
    <div>
      <div
        style={{
          display: "flex",
          flexDirection: "row",
          alignItems: "center",
          flexWrap: "wrap",
          justifyContent: "center",
          gap: 10,
        }}
      >
        <Link to="/">
          <Button color="success">Home</Button>
        </Link>
        <Link to="/calories">
          <Button color="success">Calories</Button>
        </Link>
        <Link to="/exercises-notes">
          <Button color="success">Exercises Notes</Button>
        </Link>
        <Link to="/water-notes">
          <Button color="success">Water</Button>
        </Link>
        <Link to="/recepies">
          <Button color="success">Recipes</Button>
        </Link>
        <Link to="/settings">
          <Button color="success">User Details</Button>
        </Link>
        {(user.subscription === "t-3" || isAdmin) && (
          <Link to="/stats">
            <Button color="success">Company Stats</Button>
          </Link>
        )}
        {isAdmin && (
          <Link to="/users">
            <Button color="success">Users</Button>
          </Link>
        )}
        {isAdmin && (
          <Link to="/exercises">
            <Button color="success">Exercises</Button>
          </Link>
        )}
        <Button color="success" onClick={() => logout()}>
          Logout
        </Button>
      </div>
    </div>
  );
};
