import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { CalorieNote } from "../types/CalorieNote";

export const useCalorieNoteCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: CalorieNote) => {
    const type = filter.type === "edit" ? "PUT" : "POST";

    return fetchAbstract(`CalorieNotes/`, type, {
      calories: data.calorie,
      id: data.id,
      createdAt: new Date(data.createdAt).toISOString(),
      userId: data.userId,
      recepieId: data.recepieId,
    });
  });
};
