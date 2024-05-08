import { BrowserRouter, Routes, Route } from "react-router-dom";
import App from "./App";

import { QueryClient, QueryClientProvider } from "react-query";
import { Users } from "./routes/Users";
import UsersAdd from "./routes/UsersAdd";
import { CalorieNote } from "./routes/CalorieNote";
import CalorieNoteAdd from "./routes/CalorieNoteAdd";
import { Exercises } from "./routes/Exercises";
import ExercisesAdd from "./routes/ExercisesAdd";

const queryClient = new QueryClient();

const Router = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter basename="/nure_nutri-track">
        <Routes>
          <Route path="/" element={<App />}>
            <Route index element={<>Welcome to NutriTrack</>} />
            <Route path="*" element={<>404</>} />

            <Route path="users" element={<Users />} />
            <Route path="users/add" element={<UsersAdd />} />
            <Route path="users/edit/:userId" element={<UsersAdd />} />

            <Route path="calories" element={<CalorieNote />} />
            <Route path="calories/add" element={<CalorieNoteAdd />} />
            <Route
              path="calories/edit/:calorieId"
              element={<CalorieNoteAdd />}
            />

            <Route path="exercises" element={<Exercises />} />
            <Route path="exercises/add" element={<ExercisesAdd />} />
            <Route path="exercises/edit/:id" element={<ExercisesAdd />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  );
};

export default Router;
