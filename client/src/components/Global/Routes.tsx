import { createBrowserRouter } from "react-router";
import App from "./App";
import Welcome from "./Welcome";
import ActivityDashboard from "../Activities/ActivityDashboard";
import ActivityDetails from "../Activities/ActivityDetails";
import ActivityForm from "../Activities/ActivityForm";
import LoginForm from "./LoginForm";
import RequireAuth from "./RequireAuth";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            {element: <RequireAuth/>, children: [
                {path: 'createActivity', element: <ActivityForm/>},
                {path: 'activities/manage/:id', element: <ActivityForm/>}
            ]},
            {path: '', element: <Welcome/>},
            {path: 'activities', element: <ActivityDashboard/>},
            {path: 'activities/:id', element: <ActivityDetails/>},
            {path: 'login', element: <LoginForm/>}
        ]
    }
]);