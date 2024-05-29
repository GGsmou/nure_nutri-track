import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useCalorieNoteDelete = () => {
  return useMutation((data: { id: number }) => {
    return fetchAbstract("CalorieNotes/" + data.id, "DELETE");
  });
};
