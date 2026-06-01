import { createBrowserRouter } from "react-router";
import App from "./App";
import Welcome from "./Welcome";
import ActivityDashboard from "../Activities/ActivityDashboard";
import ActivityDetails from "../Activities/ActivityDetails";
import ActivityForm from "../Activities/ActivityForm";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        children: [
            {path: '', element: <Welcome/>},
            {path: 'activities', element: <ActivityDashboard/>},
            {path: 'activities/:id', element: <ActivityDetails/>},
            {path: 'createActivity', element: <ActivityForm/>},
            {path: 'activities/manage/:id', element: <ActivityForm/>}
        ]
    }
]);